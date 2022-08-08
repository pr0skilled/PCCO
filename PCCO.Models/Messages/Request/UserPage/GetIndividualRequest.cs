namespace PCCO.Models.Messages.Request.UserPage
{
    public class GetIndividualRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string ArticleNumber { get; set; }
        public string CourtSentenceNumber { get; set; }
        public bool IsIndividual { get; set; }
    }
}
