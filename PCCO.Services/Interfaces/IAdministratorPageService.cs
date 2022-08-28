using PCCO.Models;
using PCCO.Models.Messages.Request.AdministratorPage;
using PCCO.Models.ViewModels;

namespace PCCO.Services.Interfaces
{
    public interface IAdministratorPageService
    {
        ApplicationUser? GetRegistratorById(string id);
        bool DeleteRegistrator(string id);
        List<ApplicationUser> GetRegistrators(GetRegistratorRequest request);
        string LockUnlock(string id);
        bool EditRegistrator(ApplicationUser user);
    }
}
