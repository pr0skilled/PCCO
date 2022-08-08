using Microsoft.AspNetCore.Mvc;
using System.Net;
using PCCO.Models.Messages.Request.UserPage;
using PCCO.Models.Messages.Response.UserPage;
using PCCO.Models.ViewModels;
using PCCO.Services.Interfaces;

namespace PCCO.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly IUserPageService _service;

        public HomeController(IUserPageService service)
        {
            _service = service;
        }

        public IActionResult Index(string isIndividual, string lastName, string firstName, string middleName, string? articleNumber, string courtSentenceNumber, string name, string identificationCode)
        {
            UserViewModel view = new(_service.GetArticles());
            if (isIndividual == "true")
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
                UserGetIndividualResponse pccos = _service.GetIndividuals(request);
                view.Individual = pccos.Data;
            }
            else if (isIndividual == "false")
            {
                GetLegalRequest request = new() { IdentificationCode = identificationCode, Name = name };
                UserGetLegalResponse pccos = _service.GetLegals(request);
                view.Legal = pccos.Data;
            }
            else
                ViewBag.NoData = "true";

            return View(view);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
