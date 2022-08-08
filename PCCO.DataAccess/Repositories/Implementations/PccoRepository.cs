using PCCO.DataAccess.Repositories.Interfaces;
using PCCO.Models;

namespace PCCO.DataAccess.Repositories.Implementations
{
    public class PccoRepository : GenericRepository<Pcco>, IPccoRepository
    {
        public PccoRepository(PCCOContext context) : base(context)
        {
        }
    }
}
