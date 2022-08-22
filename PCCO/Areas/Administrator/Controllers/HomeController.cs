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

        public IActionResult Index(string lastName, string idCode)
        {
            GetRegistratorRequest request = new() { IdentificationCode = idCode, LastName = lastName };
            List<ApplicationUser>? users = _service.GetRegistrators(request);
            if (users == null)
                users = new();
            return View(users);
        }

        public IActionResult Edit(string? userId)
        {
            if (userId == null)
                return View();
            else
            {
                var user = _service.GetRegistratorById(userId);
                if (user == null)
                    return Redirect("/Error"); //change

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
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                // Don't reveal that the user does not exist or is not confirmed
                TempData["error"] = "Error occured.";
                return RedirectToAction(nameof(Index), new { lastName = "" });
            }

            // For more information on how to enable account confirmation and password reset please
            // visit https://go.microsoft.com/fwlink/?LinkID=532713
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

            return RedirectToAction(nameof(MockEmail), new { callbackUrl });
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
            return RedirectToAction(nameof(Index), new { lastName = "" });
        }

        public IActionResult LockUnlock(string userId)
        {
            string status = _service.LockUnlock(userId);
            if (status == "notFound")
                return NotFound();
            else if (status == "locked")
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
