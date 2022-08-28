using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using PCCO.Models;
using PCCO.Models.Messages.Request.AdministratorPage;
using PCCO.Services.Interfaces;

namespace PCCO.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAdministratorPageService _service;
        private readonly IEmailSender _emailSender;

        public HomeController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IAdministratorPageService administratorPageService,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _service = administratorPageService;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetUsersPartial(string lastName, string idCode)
        {
            GetRegistratorRequest request = new() { IdentificationCode = idCode, LastName = lastName };
            var users = _service.GetRegistrators(request);
            foreach (var user in users)
            {
                IList<string> roles = await _userManager.GetRolesAsync(user);
                user.Role = roles.ToList();
            }
            if (!(User.HasClaim("CreateAdministrators", "True") && User.IsInRole("Administrator")))
            {
                users.RemoveAll(x => x.Role.Contains("Administrator"));
            }
            users.RemoveAll(x => x.UserName == User.Identity.Name);

            return PartialView("_PartialUsersData", users);
        }

        public IActionResult Edit(string? userId)
        {
            if (userId == null)
                return View();
            else
            {
                var user = _service.GetRegistratorById(userId);
                if (user == null)
                    TempData["error"] = "User wasn't found!";

                return View(user);
            }
        }

        [HttpPost]
        public IActionResult Edit(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                if (!_service.EditRegistrator(user))
                {
                    TempData["error"] = "Error occured while updating!";
                    return View(user);
                }
                TempData["success"] = "Updated successfully";
                string url = string.Format("/Administrator/Home?lastName=&idCode={0}", user.IdentificationCode);
                return Redirect(url);
            }

            return View(user);
        }

        public async Task<IActionResult> ResetPassword(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["error"] = "User not found!";
                return RedirectToAction(nameof(Index));
            }
            if (!(await _userManager.IsEmailConfirmedAsync(user)))
            {
                TempData["error"] = "User's email is not confirmed!";
                return RedirectToAction(nameof(Index));
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Identity/Account/ResetPassword",
                pageHandler: null,
                values: new { area = "Identity", code },
                protocol: Request.Scheme);

            await _emailSender.SendEmailAsync(
                user.Email,
                "Reset Password",
                $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
            TempData["success"] = "Password reset successfully.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Reset2FA(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.SetTwoFactorEnabledAsync(user, false);
            await _userManager.ResetAuthenticatorKeyAsync(user);
            TempData["success"] = "Authenticator app key has been reset.";
            return RedirectToPage(nameof(Index));
        }

        public IActionResult MockEmail(string url)
        {
            return View(url);
        }

        public IActionResult Delete(string userId)
        {
            bool isDeleted = _service.DeleteRegistrator(userId);
            if (!isDeleted)
                TempData["error"] = "Error occured while deleting!";
            else
                TempData["success"] = "Deleted successfully!";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult LockUnlock(string userId)
        {
            string status = _service.LockUnlock(userId);
            if (status == "locked")
                TempData["success"] = "User locked successfully!";
            else if (status == "unlocked")
                TempData["success"] = "User unlocked successfully!";
            else
                TempData["error"] = "Error occured!";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateRegistrator()
        {
            return View();
        }
    }
}
