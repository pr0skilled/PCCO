using PCCO.DataAccess.Repositories.Interfaces;
using PCCO.Models;

namespace PCCO.DataAccess.Repositories.Implementations
{
    public class PunishmentRepository : GenericRepository<Punishment>, IPunishmentRepository
    {
        public PunishmentRepository(PCCOContext context) : base(context)
        {
        }
    }
}
