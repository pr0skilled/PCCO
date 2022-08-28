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
