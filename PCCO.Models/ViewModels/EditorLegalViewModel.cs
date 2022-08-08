using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PCCO.Models.ViewModels
{
    [Serializable]
    public class EditorLegalViewModel
    {
        public int IdLegal { get; set; }

        public int IdPcco { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string Name { get; set; }

        [DisplayName("Identification code")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Contact number should have 12 digits")]
        [Range(1, 999999999999, ErrorMessage = "Identification code should not contain characters")]
        public string IdentificationCode { get; set; }

        [DisplayName("Legal form")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string LegalForm { get; set; }

        [DisplayName("Is legal entity a resident?")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public bool IsResident { get; set; }

        [DisplayName("Article number")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string ArticleNumber { get; set; }

        [DisplayName("Article title")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string ArticleTitle { get; set; }

        [DisplayName("Article content")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string ArticleContent { get; set; }

        [DisplayName("Offence description")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string OffenceDescription { get; set; }

        [DisplayName("CourtName")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string CourtName { get; set; }

        [DisplayName("Court case number")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        [RegularExpression(@"^[^\/]*\/[^\/]*\/[^\/]*$", ErrorMessage = "Court case number should contain two slahes")]
        public string CourtCaseNumber { get; set; }

        [DisplayName("Court sentence date")]
        [DataType(DataType.Date), Required(ErrorMessage = "You must enter a value for this field!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? CourtSentenceDate { get; set; }

        [DisplayName("Court sentence number")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string CourtSentenceNumber { get; set; }

        [DisplayName("Court sentence applying date")]
        [Required(ErrorMessage = "You must enter a value for this field!"), DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? CourtSentenceApplyingDate { get; set; }

        [DisplayName("Criminal record cancellation reason")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? CriminalRecordCancellationDate { get; set; }

        [DisplayName("Criminal record cancellation date")]
        public string? CriminalRecordCancellationReason { get; set; }

        [DisplayName("Is corruption record active?")]
        public bool? IsActive { get; set; }

        [DisplayName("Criminal action type")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string CriminalActionType { get; set; }

        [DisplayName("Criminal action cancellation date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? DisciplinaryActionCancellationDate { get; set; }

        [DisplayName("Disciplinary action cancellation reason")]
        public string? DisciplinaryActionCancellationReason { get; set; }

        [DisplayName("Offence method")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string OffenceMethod { get; set; }

        [DisplayName("Offence location")]
        [Required(ErrorMessage = "You must enter a value for this field!")]
        public string OffenceLocation { get; set; }
    }
}
