using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCCO.Models.Messages.Request.RegistratorPage;
using PCCO.Models.Messages.Request.UserPage;
using PCCO.Models.Messages.Response.RegistratorPage;
using PCCO.Models.ViewModels;
using PCCO.Services.Interfaces;

namespace PCCO.Areas.Registrator.Controllers
{
    [Area("Registrator")]
    [Authorize(Roles = "Registrator")]
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

        public IActionResult UpsertIndividual(int? individualId)
        {
            if (individualId == null || individualId == 0)
                return View();
            else
            {
                EditorIndividualViewModel? model = _service.GetIndividualById(individualId.Value);
                if (model == null)
                    return RedirectToAction(nameof(Error));

                return View(model);
            }
        }

        public IActionResult UpsertLegal(int? legalId)
        {
            if (legalId == null || legalId == 0)
                return View();
            else
            {
                EditorLegalViewModel? model = _service.GetLegalById(legalId.Value);
                if (model == null)
                    return RedirectToAction(nameof(Error));

                return View(model);
            }
        }

        [HttpPost]
        public IActionResult UpsertIndividual(EditorIndividualViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IdPcco == 0)
                {
                    if (!_service.AddIndividual(model))
                    {
                        TempData["error"] = "Error occured while creating!";
                        return View(model);
                    }
                    TempData["success"] = "Created successfully";
                }
                else
                {
                    if (!_service.EditIndividual(model))
                    {
                        TempData["error"] = "Error occured while updating!";
                        return View(model);
                    }
                    TempData["success"] = "Updated successfully";
                }
                string url = string.Format("/Registrator/Home?lastName={0}&firstName={1}&middleName={2}&articleNumber={3}&courtSentenceNumber={4}&IsIndividual=true", model.LastName, model.FirstName, model.MiddleName, model.ArticleNumber, model.CourtSentenceNumber);
                return Redirect(url);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult UpsertLegal(EditorLegalViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IdPcco == 0)
                {
                    if (!_service.AddLegal(model))
                    {
                        TempData["error"] = "Error occured while creating!";
                        return View(model);
                    }
                    TempData["success"] = "Created successfully";
                }
                else
                {
                    if (!_service.EditLegal(model))
                    {
                        TempData["error"] = "Error occured while updating!";
                        return View(model);
                    }
                    TempData["success"] = "Updated successfully";
                }
                string url = string.Format("/Registrator/Home?name={0}&identificationCode={1}&IsIndividual=false", model.Name, model.IdentificationCode);
                return Redirect(url);
            }
            return View(model);
        }

        public IActionResult Delete(int pccoId)
        {
            var responce = _service.DeletePcco(new DeletePccoRequest { PccoId = pccoId });
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
