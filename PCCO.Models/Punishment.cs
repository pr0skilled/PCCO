namespace PCCO.Models
{
    public partial class Punishment
    {
        public Punishment()
        {
            CorruptionRecords = new HashSet<CorruptionRecord>();
        }

        public int Id { get; set; }
        public int CriminalArticleId { get; set; }
        public string CriminalActionType { get; set; }
        public DateTime? CriminalActionCancellationDate { get; set; }
        public string? CriminalActionCancellationReason { get; set; }
        public string DisciplinaryActionType { get; set; }
        public string DisciplinaryActionDetails { get; set; }
        public DateTime? DisciplinaryActionCancellationDate { get; set; }
        public string? DisciplinaryActionCancellationReason { get; set; }

        public virtual CriminalArticle CriminalArticle { get; set; }
        public virtual ICollection<CorruptionRecord> CorruptionRecords { get; set; }
    }
}
