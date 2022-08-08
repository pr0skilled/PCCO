namespace PCCO.Models.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string[] articles)
        {
            Individual = new();
            Legal = new();
            Articles = articles;
        }

        public string[] Articles { get; set; }
        public List<UserLegalViewModel> Legal { get; set; }
        public List<UserIndividualViewModel> Individual { get; set; }
    }
}
