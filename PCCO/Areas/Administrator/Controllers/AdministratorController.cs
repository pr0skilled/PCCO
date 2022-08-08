using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PCCO.Models.ViewModels;
using PCCO.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCCO.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : Controller
    {
        private readonly IAdministratorPageService _service;

        public AdministratorController(IAdministratorPageService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            var allUsers = _service.GetAllUsers();
            return View(allUsers);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult EditRegistrator(int id)
        {
            RegistratorDto view = _service.GetRegistratorById(id);
            return View(view);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult EditRegistrator(RegistratorDto model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (!_service.EditRegistrator(model))
                return Redirect("/Home/Error");
            else
            {
                string url = string.Format("/Administrator/");
                return Redirect(url);
            }
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult CreateRegistrator()
        {
            return View();
        }


        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult CreateRegistrator(RegistratorDto model)
        {
            if (!ModelState.IsValid)
                return View(model);
            //model.Role = Models.UserRole.Recorder;
            if (!_service.AddRegistrator(model))
                return Redirect("/Home/Error");
            else
            {
                string url = string.Format("/Administrator/");
                return Redirect(url);
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var responce = _service.DeleteRegistrator(id);
            if (!responce)
                return Redirect("/Home/Error");
            return RedirectToAction("Index", "Administrator");
        }
    }
}
