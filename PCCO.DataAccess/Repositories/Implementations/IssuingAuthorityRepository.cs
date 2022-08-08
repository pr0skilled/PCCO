using PCCO.DataAccess.Repositories.Interfaces;
using PCCO.Models;

namespace PCCO.DataAccess.Repositories.Implementations
{
    public class IssuingAuthorityRepository : GenericRepository<IssuingAuthority>, IIssuingAuthorityRepository
    {
        public IssuingAuthorityRepository(PCCOContext context) : base(context)
        {
        }
    }
}
