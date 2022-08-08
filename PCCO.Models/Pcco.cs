namespace PCCO.Models
{
    public partial class Pcco
    {
        public int Id { get; set; }
        public bool IsIndividual { get; set; }
        public int? CorruptionRecordId { get; set; }
        public int? LegalEntityDataId { get; set; }
        public int? IndividualDataId { get; set; }

        public virtual CorruptionRecord CorruptionRecord { get; set; }
        public virtual IndividualData IndividualData { get; set; }
        public virtual LegalEntityData LegalEntityData { get; set; }
    }
}
