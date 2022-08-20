using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using PCCO.Models;
using PCCO.Models.Messages.Request.AdministratorPage;
using PCCO.Models.ViewModels;
using PCCO.Services.Interfaces;

namespace PCCO.Controllers
{
    [Area("Administrator")]
    //[Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAdministratorPageService _service;

        public HomeController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IAdministratorPageService administratorPageService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _service = administratorPageService;
        }

        public IActionResult Index(string lastName, string idCode)
        {
            GetRegistratorRequest request = new() { IdentificationCode = idCode, LastName = lastName };
            List<ApplicationUser>? users = _service.GetRegistrators(request);
            if (users == null)
                users = new();
            return View(users);
        }

        public IActionResult Delete(string userId)
        {
            bool isDeleted = _service.DeleteRegistrator(userId);
            if (!isDeleted)
                return Json(new { success = false, message = "Error while deleting!" });
            return Json(new { success = true, message = "Deleted Successfuly!" });
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
                TempData["error"] = "Error occured.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateRegistrator()
        {
            return View();
        }
    }
}
