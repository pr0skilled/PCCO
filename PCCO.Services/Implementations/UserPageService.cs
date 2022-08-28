using System.Net;
using PCCO.DataAccess.Repositories.Interfaces;
using PCCO.Models.Messages.Request.UserPage;
using PCCO.Models.Messages.Response.UserPage;
using PCCO.Services.Interfaces;

namespace PCCO.Services.Implementations
{
    public class UserPageService : IUserPageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserPageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string[] GetArticles()
        {
            return _unitOfWork.IndividualDataRepository.GetArticles();
        }

        public UserGetIndividualResponse GetIndividuals(GetIndividualRequest request)
        {
            var response = new UserGetIndividualResponse();
            try
            {
                response.Data = _unitOfWork.IndividualDataRepository.GetUserIndividualData(request);
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }

        public UserGetLegalResponse GetLegals(GetLegalRequest request)
        {
            var response = new UserGetLegalResponse();
            try
            {
                response.Data = _unitOfWork.LegalEntityDataRepository.GetUserLegalData(request).ToList();
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }
    }
}
