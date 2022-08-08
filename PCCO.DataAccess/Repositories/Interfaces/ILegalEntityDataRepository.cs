using PCCO.Models;
using PCCO.Models.Messages.Request.UserPage;
using PCCO.Models.ViewModels;

namespace PCCO.DataAccess.Repositories.Interfaces
{
    public interface ILegalEntityDataRepository : IGenericRepository<LegalEntityData>
    {
        List<UserLegalViewModel> GetUserLegalData(GetLegalRequest request);
        List<EditorLegalViewModel> GetEditorLegalData(GetLegalRequest request);
        EditorLegalViewModel GetEditorLegalDataById(int id);
        void AddLegal(EditorLegalViewModel model);
        void EditLegal(EditorLegalViewModel model);
    }
}
