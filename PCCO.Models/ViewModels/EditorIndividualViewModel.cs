using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PCCO.Models.ViewModels
{
    [Serializable]
    public class EditorIndividualViewModel
    {
        public int IdIndividual { get; set; }

        public int IdPcco { get; set; }

        [DisplayName("First name")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string LastName { get; set; }

        [DisplayName("Middle name")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string MiddleName { get; set; }

        [DisplayName("Identification code")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Contact number should have 10 digits")]
        [Range(1, 9999999999, ErrorMessage = "Identification code should not contain characters")]
        public string IdentificationCode { get; set; }

        [DisplayName("Work position")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string WorkPosition { get; set; }

        [DisplayName("Workplace")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string Workplace { get; set; }

        [DisplayName("Birthday")]
        [DataType(DataType.Date), Required(ErrorMessage = "You must enter a value for this field!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? Birthday { get; set; }

        [DisplayName("Birthplace")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string Birthplace { get; set; }

        [DisplayName("Residence")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string Residence { get; set; }

        [DisplayName("Series")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string Series { get; set; }

        [DisplayName("CourtName")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string CourtName { get; set; }

        [DisplayName("Court case number")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        [RegularExpression(@"^[^\/]*\/[^\/]*\/[^\/]*$", ErrorMessage = "Court case number should contain two slahes")]
        public string CourtCaseNumber { get; set; }

        [DisplayName("Court sentence date")]
        [DataType(DataType.Date), Required(ErrorMessage = "You must enter a value for this field!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? CourtSentenceDate { get; set; }

        [DisplayName("Court sentence number")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string CourtSentenceNumber { get; set; }

        [DisplayName("Court sentence applying date")]
        [DataType(DataType.Date), Required(ErrorMessage = "You must enter a value for this field!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? CourtSentenceApplyingDate { get; set; }

        [DisplayName("Criminal record cancellation date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? CriminalRecordCancellationDate { get; set; }

        [DisplayName("Criminal record cancellation reason")]
        public string? CriminalRecordCancellationReason { get; set; }

        [DisplayName("Is corruption record active?")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public bool? IsActive { get; set; }

        [DisplayName("Criminal action type")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string CriminalActionType { get; set; }

        [DisplayName("Criminal action cancellation date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? CriminalActionCancellationDate { get; set; }

        [DisplayName("Criminal action cancellation reason")]
        public string? CriminalActionCancellationReason { get; set; }

        [DisplayName("Disciplinary action type")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string DisciplinaryActionType { get; set; }

        [DisplayName("Disciplinary action details")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string DisciplinaryActionDetails { get; set; }

        [DisplayName("Disciplinary action cancellation date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DisciplinaryActionCancellationDate { get; set; }

        [DisplayName("Disciplinary action cancellation reason")]
        public string? DisciplinaryActionCancellationReason { get; set; }

        [DisplayName("Article number")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string? ArticleNumber { get; set; }

        [DisplayName("Article title")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string ArticleTitle { get; set; }

        [DisplayName("Article content")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string ArticleContent { get; set; }

        [DisplayName("Offence description")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string OffenceDescription { get; set; }

        [DisplayName("Offence method")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string OffenceMethod { get; set; }

        [DisplayName("Offence location")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string OffenceLocation { get; set; }

        [DisplayName("Code")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        [Range(1000, 9999, ErrorMessage = "Identification code should contain only 4 digits")]
        public int Code { get; set; }

        [DisplayName("Unit name")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string UnitName { get; set; }

        [DisplayName("Department name")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string DepartmentName { get; set; }

        [DisplayName("Postal code")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Postal code should have 6 digits")]
        public string PostalCode { get; set; }

        [DisplayName("City")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string City { get; set; }

        [DisplayName("Street")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string Street { get; set; }

        [DisplayName("Building number")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string BuildingNumber { get; set; }
    }
}
