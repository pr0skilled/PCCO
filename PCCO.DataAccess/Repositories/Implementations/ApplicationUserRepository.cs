using System.Linq;
using PCCO.DataAccess.Repositories.Interfaces;
using PCCO.Models;
using PCCO.Models.Messages.Request.AdministratorPage;
using PCCO.Models.ViewModels;

namespace PCCO.DataAccess.Repositories.Implementations
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        private PCCOContext _context;

        public ApplicationUserRepository(PCCOContext context) : base(context)
        {
            _context = context;
        }

        public List<ApplicationUser> GetBy(GetRegistratorRequest request)
        {
            var response = (from user in _context.ApplicationUsers
                           where (user.UserName == null || user.UserName.ToLower().Contains((request.LastName ?? string.Empty).ToLower()))
                           && (user.IdentificationCode == null || user.IdentificationCode.ToLower().Contains((request.IdentificationCode ?? string.Empty).ToLower()))
                           select user).ToList();
            return response;
        }

        public ApplicationUser? GetById(string id)
        {
            var response = _context.ApplicationUsers.FirstOrDefault(x => x.Id == id);
            return response;
        }
    }
}
