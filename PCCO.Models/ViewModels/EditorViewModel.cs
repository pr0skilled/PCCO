namespace PCCO.Models.ViewModels
{
    public class EditorViewModel
    {
        public EditorViewModel(string[] articles)
        {
            Individual = new();
            Legal = new();
            Articles = articles;
        }

        public string[] Articles { get; set; }
        public List<EditorLegalViewModel> Legal { get; set; }
        public List<EditorIndividualViewModel> Individual { get; set; }
    }
}
