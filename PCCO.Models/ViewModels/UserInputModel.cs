using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCO.Models.ViewModels
{
    public class UserInputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name ="Identification code")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Contact number should have 10 digits")]
        [Range(1, 9999999999, ErrorMessage = "Identification code should not contain characters")]
        public string IdentificationCode { get; set; }

        [Display(Name ="Workplace")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string Workplace { get; set; }

        [Display(Name ="Work position")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string WorkPosition { get; set; }

        [Display(Name ="Birthday")]
        [DataType(DataType.Date), Required(ErrorMessage = "You must enter a value for this field!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        [RegularExpression(@"^(?:\+38)?(0[5-9][0-9]\d{7})$", ErrorMessage = "Phone number should be in format '+380XXXXXXXXX'")]
        public string PhoneNumber { get; set; }
    }
}
