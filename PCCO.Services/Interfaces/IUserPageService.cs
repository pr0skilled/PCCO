using PCCO.Models.Messages.Request.UserPage;
using PCCO.Models.Messages.Response.UserPage;

namespace PCCO.Services.Interfaces
{
    public interface IUserPageService
    {
        public UserGetIndividualResponse GetIndividuals(GetIndividualRequest request);
        public UserGetLegalResponse GetLegals(GetLegalRequest request);
        public string[] GetArticles();
    }
}
