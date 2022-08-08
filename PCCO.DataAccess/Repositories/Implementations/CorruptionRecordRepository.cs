using PCCO.Models;
using PCCO.DataAccess.Repositories.Interfaces;

namespace PCCO.DataAccess.Repositories.Implementations
{
    public class CorruptionRecordRepository : GenericRepository<CorruptionRecord>, ICorruptionRecordRepository
    {
        public CorruptionRecordRepository(PCCOContext context) : base(context)
        {
        }
    }
}
