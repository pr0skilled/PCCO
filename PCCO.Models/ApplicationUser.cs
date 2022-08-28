using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PCCO.Models
{
    public partial class ApplicationUser : IdentityUser
    {
        [DisplayName("Identification code")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Contact number should have 10 digits")]
        [Range(1, 9999999999, ErrorMessage = "Identification code should not contain characters")]
        public string IdentificationCode { get; set; }

        [DisplayName("Workplace")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string Workplace { get; set; }

        [DisplayName("Work position")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string WorkPosition { get; set; }

        [DisplayName("Birthday")]
        [DataType(DataType.Date), Required(ErrorMessage = "You must enter a value for this field!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Birthday { get; set; }

        [NotMapped]
        [ValidateNever]
        public string RoleId { get; set; }

        [NotMapped]
        [ValidateNever]
        public List<string> Role { get; set; }
    }
}
