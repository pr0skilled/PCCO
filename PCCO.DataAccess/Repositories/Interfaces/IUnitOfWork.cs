using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCCO.Models;

namespace PCCO.DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        ICorruptionRecordRepository CorruptionRecordRepository { get; }
        ICrimeInfoRepository CrimeInfoRepository { get; }
        ICriminalArticleRepository CriminalArticleRepository { get; }
        IIndividualDataRepository IndividualDataRepository { get; }
        IIssuingAuthorityRepository IssuingAuthorityRepository { get; }
        ILegalEntityDataRepository LegalEntityDataRepository { get; }
        IPccoRepository PccoRepository { get; }
        IPunishmentRepository PunishmentRepository { get; }
        IApplicationUserRepository ApplicationUserRepository { get; }

        void Save();
    }
}
