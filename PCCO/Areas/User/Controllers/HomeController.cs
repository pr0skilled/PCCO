using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            string[] articles = _service.GetArticles();
            return View(articles);
        }

        public IActionResult GetIndividualsPartial(string lastName, string firstName, string middleName, string articleNumber, string courtSentenceNumber)
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
            return PartialView("_PartialUserIndData", pccos.Data);
        }

        public IActionResult GetLegalsPartial(string name, string identificationCode)
        {
            GetLegalRequest request = new() { IdentificationCode = identificationCode, Name = name };
            UserGetLegalResponse pccos = _service.GetLegals(request);
            return PartialView("_PartialUserLegData", pccos.Data);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
