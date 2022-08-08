using PCCO.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCCO.Services.Interfaces
{
    public interface IAdministratorPageService
    {
        public List<RegistratorDto> GetAllUsers();
        public RegistratorDto GetRegistratorById(int id);
        public bool EditRegistrator(RegistratorDto model);
        public bool AddRegistrator(RegistratorDto model);
        public bool DeleteRegistrator(int id);
    }
}
