namespace PCCO.Models
{
    public partial class LegalEntityData
    {
        public LegalEntityData()
        {
            Pccos = new HashSet<Pcco>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentificationCode { get; set; }
        public string LegalForm { get; set; }
        public bool IsResident { get; set; }

        public virtual ICollection<Pcco> Pccos { get; set; }
    }
}
