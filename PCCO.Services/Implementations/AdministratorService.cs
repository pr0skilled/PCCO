/*using PCCO.DataAccess.Repositories.Interfaces;
using PCCO.Models.ViewModels;
using PCCO.Repositories.Interfaces;
using PCCO.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCCO.Services.Implementations
{
    public class AdministratorPageService : IAdministratorPageService
    {
        private IUnitOfWork _unitOfWork;

        public AdministratorPageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddRegistrator(RegistratorDto model)
        {
            try
            {
                var val = _unitOfWork.ApplicationUserRepository.AddRegistrator(model);
                _unitOfWork.Save();
                return val;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteRegistrator(int id)
        {
            try
            {
                var val = _unitOfWork.ApplicationUserRepository.DeleteRegistrator(id);
                _unitOfWork.Save();
                return val;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditRegistrator(RegistratorDto model)
        {
            try
            {
                var val = _unitOfWork.ApplicationUserRepository.EditRegistrator(model);
                _unitOfWork.Save();
                return val;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<RegistratorDto> GetAllUsers()
        {
            return _unitOfWork.ApplicationUserRepository.GetAllUsers();
        }

        public RegistratorDto GetRegistratorById(int id)
        {
            try
            {
                var val = _unitOfWork.ApplicationUserRepository.GetRegistratorById(id);
                return val;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
*/