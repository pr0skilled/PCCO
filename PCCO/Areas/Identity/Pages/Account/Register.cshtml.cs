// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using PCCO.Models;

namespace PCCO.Web.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;

            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [StringLength(30, ErrorMessage = "The {0} must be at max {1} characters long.")]
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(30, ErrorMessage = "The {0} must be at max {1} characters long.")]
            [Display(Name = "Last name")]
            public string LastName { get; set; }

            [Required]
            [StringLength(30, ErrorMessage = "The {0} must be at max {1} characters long.")]
            [Display(Name = "Middle name")]
            public string MiddleName { get; set; }

            [DisplayName("Identification code")]
            [Required(ErrorMessage = "You must enter a value for this field!")]
            [StringLength(10, MinimumLength = 10, ErrorMessage = "Contact number should have 10 digits")]
            [Range(1, 9999999999, ErrorMessage = "Identification code should not contain characters")]
            public string IdentificationCode { get; set; }

            [DisplayName("Workplace")]
            [Required(ErrorMessage = "You must enter a value for this field!")]
            public string Workplace { get; set; }

            [DisplayName("Work position")]
            [Required(ErrorMessage = "You must enter a value for this field!")]
            public string WorkPosition { get; set; }

            [DisplayName("Birthday")]
            [DataType(DataType.Date), Required(ErrorMessage = "You must enter a value for this field!")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
            public DateTime Birthday { get; set; }

            [DisplayName("Phone number")]
            [Required(ErrorMessage = "You must enter a value for this field!")]
            [RegularExpression(@"^(?:\+38)?(0[5-9][0-9]\d{7})$", ErrorMessage = "Phone number should be in format '+380XXXXXXXXX'")]
            public string PhoneNumber { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                string userName = string.Join(" ", Input.LastName, Input.FirstName, Input.MiddleName);
                await _userStore.SetUserNameAsync(user, userName, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                user.IdentificationCode = Input.IdentificationCode;
                user.Workplace = Input.Workplace;
                user.WorkPosition = Input.WorkPosition;
                user.Birthday = Input.Birthday;
                user.PhoneNumber = Input.PhoneNumber;
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _userManager.AddToRoleAsync(user, "Registrator");
                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href=\"{HtmlEncoder.Default.Encode(callbackUrl)}\">clicking here</a>.");
                    TempData["success"] = "New User Created Successfully";
                    return Redirect(string.Format("/Administrator/Home?lastName=&idCode={0}", user.IdentificationCode));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<IdentityUser>)_userStore;
        }
    }
}
