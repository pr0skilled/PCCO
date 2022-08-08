using PCCO.Models.Messages.Request.RegistratorPage;
using PCCO.Models.Messages.Request.UserPage;
using PCCO.Models.Messages.Response.RegistratorPage;
using PCCO.Models.ViewModels;

namespace PCCO.Services.Interfaces
{
    public interface IRegistratorPageService
    {
        public RegistratorGetIndividualResponse GetIndividuals(GetIndividualRequest request);
        public RegistratorGetLegalResponse GetLegals(GetLegalRequest request);
        public EditorIndividualViewModel? GetIndividualById(int indId);
        public EditorLegalViewModel? GetLegalById(int legId);
        public bool AddIndividual(EditorIndividualViewModel model);
        public bool AddLegal(EditorLegalViewModel model);
        public bool EditIndividual(EditorIndividualViewModel model);
        public bool EditLegal(EditorLegalViewModel model);
        public DeletePccoResponse DeletePcco(DeletePccoRequest request);
        public string[] GetArticles();
    }
}
