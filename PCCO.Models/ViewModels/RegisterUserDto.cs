using System.ComponentModel.DataAnnotations;

namespace PCCO.Models.ViewModels
{
    public class RegistratorDto
    {
        public int UserId { get; set; }
        public int IndividualDataId { get; set; }
        [Required(ErrorMessage = "You must enter a value for this field!"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        public string Password { get; set; }
        public int UserWorkplaceId { get; set; }
        public UserRole Role { get; set; }

        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "You must enter a value for this field!")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Identification code should have 8 digits")]
        [Range(10000000, 99999999, ErrorMessage = "Identification code should not contain characters")]
        public string IdentificationCode { get; set; }
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string WorkPosition { get; set; }
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string Workplace { get; set; }
        [DataType(DataType.Date), Required(ErrorMessage = "You must enter a value for this field!")]
        public DateTime? Birthday { get; set; }
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string Birthplace { get; set; }
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string Residence { get; set; }
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string Series { get; set; }

        public int Code { get; set; }
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string UnitName { get; set; }
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "You must enter a value for this field!")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Postal code should have 6 digits")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string Oblast { get; set; }
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string City { get; set; }
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string Street { get; set; }
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string BuildingNumber { get; set; }
        
    }
}
