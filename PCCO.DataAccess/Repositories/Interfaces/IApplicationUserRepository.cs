using PCCO.Models;
using PCCO.Models.Messages.Request.AdministratorPage;
using PCCO.Models.ViewModels;

namespace PCCO.DataAccess.Repositories.Interfaces
{
    public interface IApplicationUserRepository : IGenericRepository<ApplicationUser>
    {
        List<ApplicationUser> GetBy(GetRegistratorRequest request);
        ApplicationUser? GetById(string id);
    }
}
