using PCCO.DataAccess.Repositories.Interfaces;
using PCCO.Models;

namespace PCCO.DataAccess.Repositories.Implementations
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(PCCOContext context) : base(context)
        {
        }
    }
}
