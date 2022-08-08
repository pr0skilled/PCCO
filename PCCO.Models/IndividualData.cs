namespace PCCO.Models
{
    public partial class IndividualData
    {
        public IndividualData()
        {
            Pccos = new HashSet<Pcco>();
            Users = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string IdentificationCode { get; set; }
        public string WorkPosition { get; set; }
        public int IssuingAuthorityId { get; set; }
        public string Workplace { get; set; }
        public DateTime Birthday { get; set; }
        public string Birthplace { get; set; }
        public string Residence { get; set; }
        public string Series { get; set; }

        public virtual IssuingAuthority IssuingAuthority { get; set; }
        public virtual ICollection<Pcco> Pccos { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
