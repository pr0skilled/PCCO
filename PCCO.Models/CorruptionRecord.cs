namespace PCCO.Models
{
    public partial class CorruptionRecord
    {
        public CorruptionRecord()
        {
            Pccos = new HashSet<Pcco>();
        }

        public int Id { get; set; }
        public int CrimeInfoId { get; set; }
        public int PunishmentId { get; set; }
        public string CourtName { get; set; }
        public string CourtCaseNumber { get; set; }
        public DateTime CourtSentenceDate { get; set; }
        public string CourtSentenceNumber { get; set; }
        public DateTime CourtSentenceApplyingDate { get; set; }
        public DateTime? CriminalRecordCancellationDate { get; set; }
        public string? CriminalRecordCancellationReason { get; set; }
        public bool? IsActive { get; set; }

        public virtual CrimeInfo CrimeInfo { get; set; }
        public virtual Punishment Punishment { get; set; }
        public virtual ICollection<Pcco> Pccos { get; set; }
    }
}
