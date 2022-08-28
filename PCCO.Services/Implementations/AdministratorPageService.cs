using PCCO.DataAccess.Repositories.Interfaces;
using PCCO.Models;
using PCCO.Models.Messages.Request.AdministratorPage;
using PCCO.Models.ViewModels;
using PCCO.Services.Interfaces;

namespace PCCO.Services.Implementations
{
    public class AdministratorPageService : IAdministratorPageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdministratorPageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ApplicationUser> GetRegistrators(GetRegistratorRequest request)
        {
            var response = new List<ApplicationUser>();
            try
            {
                response = _unitOfWork.ApplicationUserRepository.GetBy(request);
            }
            catch (Exception) { }
            return response ?? new List<ApplicationUser>();
        }

        ApplicationUser? IAdministratorPageService.GetRegistratorById(string id)
        {
            try
            {
                var response = _unitOfWork.ApplicationUserRepository.GetById(id);
                return response;
            }
            catch
            {
                return null;
            }
        }

        public bool DeleteRegistrator(string id)
        {
            try
            {
                var user = _unitOfWork.ApplicationUserRepository.GetById(id);
                if (user != null)
                {
                    _unitOfWork.ApplicationUserRepository.Delete(user);
                    _unitOfWork.Save();
                    return true;
                }
                else throw new Exception($"User with id '{id}' was not found");
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string LockUnlock(string id)
        {
            string response;
            try
            {
                var user = _unitOfWork.ApplicationUserRepository.GetById(id);
                if (user == null)
                    response = "notFound";
                if (user.LockoutEnd != null && user.LockoutEnd > DateTime.Now)
                {
                    //user is locked and will remain locked untill lockoutend time
                    //clicking on this action will unlock them
                    user.LockoutEnd = DateTime.Now;
                    _unitOfWork.Save();
                    response = "unlocked";
                }
                else
                {
                    //user is not locked, and we want to lock the user
                    user.LockoutEnd = DateTime.Now.AddYears(1000);
                    _unitOfWork.Save();
                    response = "locked";
                }
                return response;
            }
            catch (Exception)
            {
                return "error";
            }
        }

        public bool EditRegistrator(ApplicationUser user)
        {
            try
            {
                _unitOfWork.ApplicationUserRepository.Update(user);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
