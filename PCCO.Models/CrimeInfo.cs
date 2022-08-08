namespace PCCO.Models
{
    public partial class CrimeInfo
    {
        public CrimeInfo()
        {
            CorruptionRecords = new HashSet<CorruptionRecord>();
        }

        public int Id { get; set; }
        public string OffenceDescription { get; set; }
        public string OffenceMethod { get; set; }
        public string OffenceLocation { get; set; }

        public virtual ICollection<CorruptionRecord> CorruptionRecords { get; set; }
    }
}
