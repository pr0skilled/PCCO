using PCCO.Models.ViewModels;

namespace PCCO.Models.Messages.Response.RegistratorPage
{
    public class RegistratorGetLegalResponse : ResponseBase
    {
        public List<EditorLegalViewModel> Data { get; set; }
    }
}
