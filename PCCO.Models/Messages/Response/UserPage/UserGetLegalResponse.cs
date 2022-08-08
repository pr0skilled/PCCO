using PCCO.Models.ViewModels;

namespace PCCO.Models.Messages.Response.UserPage
{
    public class UserGetLegalResponse : ResponseBase
    {
        public List<UserLegalViewModel> Data { get; set; }
    }
}
