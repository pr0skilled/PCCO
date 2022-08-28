using PCCO.DataAccess.Repositories.Interfaces;
using PCCO.Models;
using PCCO.Models.Messages.Request.UserPage;
using PCCO.Models.ViewModels;

namespace PCCO.DataAccess.Repositories.Implementations
{
    public class LegalEntityDataRepository : GenericRepository<LegalEntityData>, ILegalEntityDataRepository
    {
        private PCCOContext _context;

        public LegalEntityDataRepository(PCCOContext context) : base(context)
        {
            _context = context;
        }

        public List<UserLegalViewModel> GetUserLegalData(GetLegalRequest request)
        {
            var response = from l in _context.LegalEntityData
                           join pcco in _context.Pccos on l.Id equals pcco.LegalEntityDataId
                           join c in _context.CorruptionRecords on pcco.CorruptionRecordId equals c.Id
                           join cr in _context.CrimeInfos on c.CrimeInfoId equals cr.Id
                           join p in _context.Punishments on c.PunishmentId equals p.Id
                           join ar in _context.CriminalArticles on p.CriminalArticleId equals ar.Id
                           where (l.IdentificationCode == null || l.IdentificationCode.Contains(request.IdentificationCode ?? string.Empty))
                                 && (l.Name == null || l.Name.ToLower().Contains((request.Name ?? string.Empty).ToLower()))
                           select new UserLegalViewModel
                           {
                               Name = l.Name,
                               IdentificationCode = l.IdentificationCode,
                               OffenceDescription = cr.OffenceDescription,
                               DisciplinaryActionDetails = p.DisciplinaryActionDetails,
                           };
            return response.ToList();
        }

        public List<EditorLegalViewModel> GetEditorLegalData(GetLegalRequest request)
        {
            var response = from l in _context.LegalEntityData
                           join pcco in _context.Pccos on l.Id equals pcco.LegalEntityDataId
                           join c in _context.CorruptionRecords on pcco.CorruptionRecordId equals c.Id
                           join cr in _context.CrimeInfos on c.CrimeInfoId equals cr.Id
                           join p in _context.Punishments on c.PunishmentId equals p.Id
                           join ar in _context.CriminalArticles on p.CriminalArticleId equals ar.Id
                           where (l.IdentificationCode == null || l.IdentificationCode.Contains(request.IdentificationCode ?? string.Empty))
                                 && (l.Name == null || l.Name.ToLower().Contains((request.Name ?? string.Empty).ToLower()))
                           select new EditorLegalViewModel
                           {
                               IdLegal = l.Id,
                               IdPcco = pcco.Id,
                               Name = l.Name,
                               IdentificationCode = l.IdentificationCode,
                               LegalForm = l.LegalForm,
                               IsResident = l.IsResident,
                               ArticleNumber = ar.ArticleNumber,
                               ArticleTitle = ar.ArticleTitle,
                               ArticleContent = ar.ArticleContent,
                               OffenceDescription = cr.OffenceDescription,
                               CourtName = c.CourtName,
                               CourtCaseNumber = c.CourtCaseNumber,
                               CourtSentenceDate = c.CourtSentenceDate,
                               CourtSentenceNumber = c.CourtSentenceNumber,
                               CourtSentenceApplyingDate = c.CourtSentenceApplyingDate,
                               CriminalRecordCancellationDate = c.CriminalRecordCancellationDate,
                               CriminalRecordCancellationReason = c.CriminalRecordCancellationReason,
                               IsActive = c.IsActive,
                               CriminalActionType = p.CriminalActionType,
                               CriminalActionCancellationDate = p.CriminalActionCancellationDate,
                               CriminalActionCancellationReason = p.CriminalActionCancellationReason,
                               DisciplinaryActionType = p.DisciplinaryActionType,
                               DisciplinaryActionDetails = p.DisciplinaryActionDetails,
                               DisciplinaryActionCancellationDate = p.DisciplinaryActionCancellationDate,
                               DisciplinaryActionCancellationReason = p.DisciplinaryActionCancellationReason,
                               OffenceLocation = cr.OffenceDescription,
                               OffenceMethod = cr.OffenceMethod
                           };
            return response.ToList();
        }

        public EditorLegalViewModel GetEditorLegalDataById(int id)
        {
            var response = from leg in _context.LegalEntityData
                           join pcco in _context.Pccos on leg.Id equals pcco.LegalEntityDataId
                           join c in _context.CorruptionRecords on pcco.CorruptionRecordId equals c.Id
                           join cr in _context.CrimeInfos on c.CrimeInfoId equals cr.Id
                           join p in _context.Punishments on c.PunishmentId equals p.Id
                           join ar in _context.CriminalArticles on p.CriminalArticleId equals ar.Id
                           where (id == leg.Id)
                           select new EditorLegalViewModel
                           {
                               IdLegal = leg.Id,
                               IdPcco = pcco.Id,
                               Name = leg.Name,
                               IdentificationCode = leg.IdentificationCode,
                               LegalForm = leg.LegalForm,
                               IsResident = leg.IsResident,
                               CourtName = c.CourtName,
                               CourtCaseNumber = c.CourtCaseNumber,
                               CourtSentenceDate = c.CourtSentenceDate,
                               CourtSentenceNumber = c.CourtSentenceNumber,
                               CourtSentenceApplyingDate = c.CourtSentenceApplyingDate,
                               CriminalRecordCancellationDate = c.CriminalRecordCancellationDate,
                               CriminalRecordCancellationReason = c.CriminalRecordCancellationReason,
                               IsActive = c.IsActive,
                               CriminalActionType = p.CriminalActionType,
                               CriminalActionCancellationDate = p.CriminalActionCancellationDate,
                               CriminalActionCancellationReason = p.CriminalActionCancellationReason,
                               DisciplinaryActionType = p.DisciplinaryActionType,
                               DisciplinaryActionDetails = p.DisciplinaryActionDetails,
                               DisciplinaryActionCancellationDate = p.DisciplinaryActionCancellationDate,
                               DisciplinaryActionCancellationReason = p.DisciplinaryActionCancellationReason,
                               ArticleNumber = ar.ArticleNumber,
                               ArticleTitle = ar.ArticleTitle,
                               ArticleContent = ar.ArticleContent,
                               OffenceDescription = cr.OffenceDescription,
                               OffenceMethod = cr.OffenceMethod,
                               OffenceLocation = cr.OffenceLocation
                           };
            return response.FirstOrDefault();
        }

        public void AddLegal(EditorLegalViewModel model)
        {
            var legalData = new LegalEntityData
            {
                Name = model.Name,
                IdentificationCode = model.IdentificationCode,
                LegalForm = model.LegalForm,
                IsResident = model.IsResident,
            };
            _context.Add(legalData);

            var criminalArticle = new CriminalArticle
            {
                ArticleContent = model.ArticleContent,
                ArticleNumber = model.ArticleNumber,
                ArticleTitle = model.ArticleTitle
            };
            _context.Add(criminalArticle);

            var punishment = new Punishment
            {
                CriminalArticle = criminalArticle,
                CriminalActionCancellationDate = model.CriminalActionCancellationDate,
                CriminalActionCancellationReason = model.CriminalActionCancellationReason,
                CriminalActionType = model.CriminalActionType,
                DisciplinaryActionCancellationDate = model.DisciplinaryActionCancellationDate,
                DisciplinaryActionCancellationReason = model.DisciplinaryActionCancellationReason,
                DisciplinaryActionDetails = model.DisciplinaryActionDetails,
                DisciplinaryActionType = model.DisciplinaryActionType
            };
            _context.Add(punishment);

            var crimeInfo = new CrimeInfo
            {
                OffenceDescription = model.OffenceDescription,
                OffenceLocation = model.OffenceLocation,
                OffenceMethod = model.OffenceMethod
            };
            _context.Add(crimeInfo);

            var corruptionRecord = new CorruptionRecord
            {
                CrimeInfo = crimeInfo,
                Punishment = punishment,
                CourtCaseNumber = model.CourtCaseNumber,
                CourtName = model.CourtName,
                CourtSentenceApplyingDate = model.CourtSentenceApplyingDate.Value,
                CourtSentenceDate = model.CourtSentenceDate.Value,
                CourtSentenceNumber = model.CourtSentenceNumber,
                CriminalRecordCancellationDate = model.CriminalRecordCancellationDate,
                CriminalRecordCancellationReason = model.CriminalActionCancellationReason,
                IsActive = true
            };
            _context.Add(corruptionRecord);

            var pcco = new Pcco { IsIndividual = false, CorruptionRecord = corruptionRecord, IndividualData = null, LegalEntityData = legalData };
            _context.Add(pcco);
        }

        public void EditLegal(EditorLegalViewModel model)
        {
            var pcco = _context.Pccos.Find(model.IdPcco);
            if (pcco == null)
                throw new Exception("No legal entity with such id");

            var corruptionRecord = _context.CorruptionRecords.Find(pcco.CorruptionRecordId);
            var crimeInfo = _context.CrimeInfos.Find(corruptionRecord.CrimeInfoId);
            var punishment = _context.Punishments.Find(corruptionRecord.PunishmentId);
            var criminalArticle = _context.CriminalArticles.Find(punishment.CriminalArticleId);
            var legalData = _context.LegalEntityData.Find(pcco.LegalEntityDataId);

            legalData.Name = model.Name;
            legalData.IdentificationCode = model.IdentificationCode;
            legalData.LegalForm = model.LegalForm;
            legalData.IsResident = model.IsResident;

            criminalArticle.ArticleContent = model.ArticleContent;
            criminalArticle.ArticleNumber = model.ArticleNumber;
            criminalArticle.ArticleTitle = model.ArticleTitle;

            punishment.CriminalArticle = criminalArticle;
            punishment.CriminalActionCancellationDate = model.CriminalActionCancellationDate;
            punishment.CriminalActionCancellationReason = model.CriminalActionCancellationReason;
            punishment.CriminalActionType = model.CriminalActionType;
            punishment.DisciplinaryActionCancellationDate = model.DisciplinaryActionCancellationDate;
            punishment.DisciplinaryActionCancellationReason = model.DisciplinaryActionCancellationReason;
            punishment.DisciplinaryActionDetails = model.DisciplinaryActionDetails;
            punishment.DisciplinaryActionType = model.DisciplinaryActionType;

            crimeInfo.OffenceDescription = model.OffenceDescription;
            crimeInfo.OffenceLocation = model.OffenceLocation;
            crimeInfo.OffenceMethod = model.OffenceMethod;

            corruptionRecord.CrimeInfo = crimeInfo;
            corruptionRecord.Punishment = punishment;
            corruptionRecord.CourtCaseNumber = model.CourtCaseNumber;
            corruptionRecord.CourtName = model.CourtName;
            corruptionRecord.CourtSentenceApplyingDate = model.CourtSentenceApplyingDate.Value;
            corruptionRecord.CourtSentenceDate = model.CourtSentenceDate.Value;
            corruptionRecord.CourtSentenceNumber = model.CourtSentenceNumber;
            corruptionRecord.CriminalRecordCancellationDate = model.CriminalRecordCancellationDate;
            corruptionRecord.CriminalRecordCancellationReason = model.CriminalActionCancellationReason;
            corruptionRecord.IsActive = model.IsActive;

            pcco.IsIndividual = false;
            pcco.CorruptionRecord = corruptionRecord;
            pcco.LegalEntityData = legalData;
        }
    }
}