using PCCO.Models.ViewModels;

namespace PCCO.Models.Messages.Response.UserPage
{
    public class UserGetIndividualResponse : ResponseBase
    {
        public List<UserIndividualViewModel> Data { get; set; }
    }
}
