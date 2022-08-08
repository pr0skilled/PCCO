using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCCO.DataAccess.Repositories.Interfaces;

namespace PCCO.DataAccess.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private PCCOContext _context;

        public UnitOfWork(PCCOContext context)
        {
            _context = context;
            CorruptionRecordRepository = new CorruptionRecordRepository(_context);
            CrimeInfoRepository = new CrimeInfoRepository(_context);
            CriminalArticleRepository = new CriminalArticleRepository(_context);
            IndividualDataRepository = new IndividualDataRepository(_context);
            IssuingAuthorityRepository = new IssuingAuthorityRepository(_context);
            LegalEntityDataRepository = new LegalEntityDataRepository(_context);
            PccoRepository = new PccoRepository(_context);
            PunishmentRepository = new PunishmentRepository(_context);
            ApplicationUserRepository = new ApplicationUserRepository(_context);
        }

        public ICorruptionRecordRepository CorruptionRecordRepository { get; private set; }
        public ICrimeInfoRepository CrimeInfoRepository { get; private set; }
        public ICriminalArticleRepository CriminalArticleRepository { get; private set; }
        public IIndividualDataRepository IndividualDataRepository { get; private set; }
        public IIssuingAuthorityRepository IssuingAuthorityRepository { get; private set; }
        public ILegalEntityDataRepository LegalEntityDataRepository { get; private set; }
        public IPccoRepository PccoRepository { get; private set; }
        public IPunishmentRepository PunishmentRepository { get; private set; }
        public IApplicationUserRepository ApplicationUserRepository { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
