using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PCCO.Models;
using PCCO.Models.Messages.Request.AdministratorPage;
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

        public IActionResult Delete(string userId)
        {
            bool isDeleted = _service.DeleteRegistrator(userId);
            if (!isDeleted)
                TempData["error"] = "Error occured while deleting!";
            else
                TempData["success"] = "Deleted successfully";
            return RedirectToAction("Index", new { lastName = "" });
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
