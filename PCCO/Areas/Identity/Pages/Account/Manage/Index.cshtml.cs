﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PCCO.DataAccess;
using PCCO.Models;

namespace PCCO.Web.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly PCCOContext _context;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            PCCOContext context,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }

        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            [RegularExpression(@"^(?:\+38)?(0[5-9][0-9]\d{7})$", ErrorMessage = "Phone number should be in format '+380XXXXXXXXX'")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Name")]
            public string Username { get; set; }
            public DateTime Birthday { get; set; }

            [Display(Name = "Identification code")]
            public string IdentificationCode { get; set; }
            public string Workplace { get; set; }

            [Display(Name = "Work position")]
            public string WorkPosition { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            Input = new InputModel
            {
                PhoneNumber = user.PhoneNumber,
                Username = user.UserName,
                Birthday = user.Birthday,
                IdentificationCode = user.IdentificationCode,
                Workplace = user.Workplace,
                WorkPosition = user.WorkPosition
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            user.UserName = Input.Username;
            user.IdentificationCode = Input.IdentificationCode;
            user.Workplace = Input.Workplace;
            user.WorkPosition = Input.WorkPosition;
            user.Birthday = Input.Birthday;
            user.PhoneNumber = Input.PhoneNumber;
            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
