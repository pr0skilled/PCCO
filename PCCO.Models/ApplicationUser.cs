using Microsoft.AspNetCore.Identity;

namespace PCCO.Models
{
    public partial class ApplicationUser : IdentityUser
    {
        public int IndividualDataId { get; set; }

        public virtual IndividualData IndividualData { get; set; }
    }
}
