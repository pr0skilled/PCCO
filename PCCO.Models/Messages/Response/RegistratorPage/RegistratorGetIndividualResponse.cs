using PCCO.Models.ViewModels;

namespace PCCO.Models.Messages.Response.RegistratorPage
{
    public class RegistratorGetIndividualResponse : ResponseBase
    {
        public List<EditorIndividualViewModel> Data { get; set; }
    }
}
