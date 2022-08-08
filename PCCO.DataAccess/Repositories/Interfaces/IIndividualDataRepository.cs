using PCCO.Models;
using PCCO.Models.Messages.Request.UserPage;
using PCCO.Models.ViewModels;

namespace PCCO.DataAccess.Repositories.Interfaces
{
    public interface IIndividualDataRepository : IGenericRepository<IndividualData>
    {
        List<UserIndividualViewModel> GetUserIndividualData(GetIndividualRequest request);
        List<EditorIndividualViewModel> GetEditorIndividualData(GetIndividualRequest request);
        EditorIndividualViewModel GetEditorIndividualDataById(int id);
        void AddIndividual(EditorIndividualViewModel model);
        void EditIndividual(EditorIndividualViewModel model);
        string[] GetArticles();
    }
}
