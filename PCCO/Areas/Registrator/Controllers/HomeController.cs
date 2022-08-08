using Microsoft.AspNetCore.Mvc;
using PCCO.Models.Messages.Request.RegistratorPage;
using PCCO.Models.Messages.Request.UserPage;
using PCCO.Models.Messages.Response.RegistratorPage;
using PCCO.Models.ViewModels;
using PCCO.Services.Interfaces;

namespace PCCO.Areas.Registrator.Controllers
{
    [Area("Registrator")]
    public class HomeController : Controller
    {
        private readonly IRegistratorPageService _service;

        public HomeController(IRegistratorPageService service)
        {
            _service = service;
        }

        public IActionResult Index(string IsIndividual, string lastName, string firstName, string middleName, string? articleNumber, string courtSentenceNumber, string name, string identificationCode)
        {
            EditorViewModel view = new(_service.GetArticles());
            if (IsIndividual == "true")
            {
                GetIndividualRequest request = new()
                {
                    LastName = lastName,
                    MiddleName = middleName,
                    FirstName = firstName,
                    ArticleNumber = articleNumber,
                    CourtSentenceNumber = courtSentenceNumber,
                    IsIndividual = true
                };
                RegistratorGetIndividualResponse pccos = _service.GetIndividuals(request);
                view.Individual = pccos.Data;
            }
            else if (IsIndividual == "false")
            {
                GetLegalRequest request = new() { IdentificationCode = identificationCode, Name = name };
                RegistratorGetLegalResponse pccos = _service.GetLegals(request);
                view.Legal = pccos.Data;
            }
            else
                ViewBag.NoData = "true";

            return View(view);
        }

        public IActionResult EditIndividual(int individualId)
        {
            EditorIndividualViewModel? model = _service.GetIndividualById(individualId);
            if (model == null)
                return RedirectToAction(nameof(Error));

            return View(model);
        }

        public IActionResult EditLegal(int legalId)
        {
            EditorLegalViewModel? model = _service.GetLegalById(legalId);
            if (model == null)
                return RedirectToAction(nameof(Error));

            return View(model);
        }

        [HttpPost]
        public IActionResult EditIndividual(EditorIndividualViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (!_service.EditIndividual(model))
                return RedirectToAction(nameof(Error));
            else
            {
                string url = string.Format("/Registrator/Home?lastName={0}&firstName={1}&middleName={2}&articleNumber={3}&courtSentenceNumber={4}&IsIndividual=true", model.LastName, model.FirstName, model.MiddleName, model.ArticleNumber, model.CourtSentenceNumber);
                return Redirect(url);
            }
        }

        [HttpPost]
        public IActionResult EditLegal(EditorLegalViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (!_service.EditLegal(model))
                return RedirectToAction(nameof(Error));
            else
            {
                string url = string.Format("/Registrator/Home?name={0}&identificationCode={1}&IsIndividual=false", model.Name, model.IdentificationCode);
                return Redirect(url);
            }
        }

        public IActionResult CreateIndividual()
        {
            return View();
        }

        public IActionResult CreateLegal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateIndividual(EditorIndividualViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (!_service.AddIndividual(model))
            {
                return View(model); //Add error notification
            }
            else
            {
                string url = string.Format("/Registrator/Home?lastName={0}&firstName={1}&middleName={2}&articleNumber={3}&courtSentenceNumber={4}&IsIndividual=true", model.LastName, model.FirstName, model.MiddleName, model.ArticleNumber, model.CourtSentenceNumber);
                return Redirect(url);
            }
        }

        [HttpPost]
        public IActionResult CreateLegal(EditorLegalViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (!_service.AddLegal(model))
            {
                return View(model); //Add error notification
            }
            else
            {
                string url = string.Format("/Registrator/Home?name={0}&identificationCode={1}&IsIndividual=false", model.Name, model.IdentificationCode);
                return Redirect(url);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var responce = _service.DeletePcco(new DeletePccoRequest { Id = id });
            if (!responce.IsDeleted)
                return Json(new { success = false, message = "Error while deleting" });
            return Json(new { success = true, message = "Deleted Successfuly" });
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
