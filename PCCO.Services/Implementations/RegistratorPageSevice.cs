using System.Net;
using PCCO.DataAccess.Repositories.Interfaces;
using PCCO.Models.Messages.Request.RegistratorPage;
using PCCO.Models.Messages.Request.UserPage;
using PCCO.Models.Messages.Response.RegistratorPage;
using PCCO.Models.ViewModels;
using PCCO.Services.Interfaces;

namespace PCCO.Services.Implementations
{
    public class RegistratorPageSevice : IRegistratorPageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegistratorPageSevice(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RegistratorGetIndividualResponse GetIndividuals(GetIndividualRequest request)
        {
            var response = new RegistratorGetIndividualResponse();
            try
            {
                response.Data = _unitOfWork.IndividualDataRepository.GetEditorIndividualData(request);
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }

        public RegistratorGetLegalResponse GetLegals(GetLegalRequest request)
        {
            var response = new RegistratorGetLegalResponse();
            try
            {
                response.Data = _unitOfWork.LegalEntityDataRepository.GetEditorLegalData(request);
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }

        public EditorIndividualViewModel? GetIndividualById(int indId)
        {
            try
            {
                var response = _unitOfWork.IndividualDataRepository.GetEditorIndividualDataById(id: indId);
                return response;
            }
            catch
            {
                return null;
            }
        }

        public EditorLegalViewModel? GetLegalById(int legId)
        {
            try
            {
                var response = _unitOfWork.LegalEntityDataRepository.GetEditorLegalDataById(id: legId);
                return response;
            }
            catch
            {
                return null;
            }
        }

        public bool AddIndividual(EditorIndividualViewModel model)
        {
            try
            {
                _unitOfWork.IndividualDataRepository.AddIndividual(model);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool AddLegal(EditorLegalViewModel model)
        {
            try
            {
                _unitOfWork.LegalEntityDataRepository.AddLegal(model);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditIndividual(EditorIndividualViewModel model)
        {
            try
            {
                _unitOfWork.IndividualDataRepository.EditIndividual(model);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditLegal(EditorLegalViewModel model)
        {
            try
            {
                _unitOfWork.LegalEntityDataRepository.EditLegal(model);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DeletePccoResponse DeletePcco(DeletePccoRequest request)
        {
            DeletePccoResponse response = new DeletePccoResponse();
            try
            {
                var entity = _unitOfWork.PccoRepository.GetById(request.Id);
                _unitOfWork.PccoRepository.Delete(entity);
                _unitOfWork.Save();
                response.IsDeleted = true;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsDeleted = false;
            }
            return response;
        }

        public string[] GetArticles()
        {
            return _unitOfWork.IndividualDataRepository.GetArticles();
        }
    }
}
