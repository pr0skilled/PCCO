using PCCO.DataAccess.Repositories.Interfaces;
using PCCO.Models;

namespace PCCO.DataAccess.Repositories.Implementations
{
    public class CrimeInfoRepository : GenericRepository<CrimeInfo>, ICrimeInfoRepository
    {
        public CrimeInfoRepository(PCCOContext context) : base(context)
        {
        }
    }
}
