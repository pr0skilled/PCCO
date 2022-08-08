using PCCO.DataAccess.Repositories.Interfaces;
using PCCO.Models;

namespace PCCO.DataAccess.Repositories.Implementations
{
    public class CriminalArticleRepository : GenericRepository<CriminalArticle>, ICriminalArticleRepository
    {
        public CriminalArticleRepository(PCCOContext context) : base(context) {}
    }
}
