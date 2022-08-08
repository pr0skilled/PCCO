namespace PCCO.Models.ViewModels
{
    public class UserIndividualViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string WorkPosition { get; set; }
        public string Workplace { get; set; }
        public string OffenceDescription { get; set; }
        public string? ArticleNumber { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }
        public string CourtName { get; set; }
        public string CourtCaseNumber { get; set; }
        public DateTime CourtSentenceDate { get; set; }
        public string CourtSentenceNumber { get; set; }
        public DateTime CourtSentenceApplyingDate { get; set; }
        public string DisciplinaryActionDetails { get; set; }
        public string IsActive { get; set; }
    }
}
