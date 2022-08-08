namespace PCCO.Models
{
    public partial class IssuingAuthority
    {
        public IssuingAuthority()
        {
            IndividualData = new HashSet<IndividualData>();
        }

        public int Id { get; set; }
        public int Code { get; set; }
        public string UnitName { get; set; }
        public string DepartmentName { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }

        public virtual ICollection<IndividualData> IndividualData { get; set; }
    }
}
