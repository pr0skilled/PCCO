using PCCO.DataAccess.Repositories.Interfaces;
using PCCO.Models;
using PCCO.Models.Messages.Request.UserPage;
using PCCO.Models.ViewModels;

namespace PCCO.DataAccess.Repositories.Implementations
{
    public class IndividualDataRepository : GenericRepository<IndividualData>, IIndividualDataRepository
    {
        private PCCOContext _context;

        public IndividualDataRepository(PCCOContext context) : base(context)
        {
            _context = context;
        }

        public List<UserIndividualViewModel> GetUserIndividualData(GetIndividualRequest request)
        {
            var response = from ind in _context.IndividualData
                           join pcco in _context.Pccos on ind.Id equals pcco.IndividualDataId
                           join c in _context.CorruptionRecords on pcco.CorruptionRecordId equals c.Id
                           join cr in _context.CrimeInfos on c.CrimeInfoId equals cr.Id
                           join p in _context.Punishments on c.PunishmentId equals p.Id
                           join ar in _context.CriminalArticles on p.CriminalArticleId equals ar.Id
                           where (ind.FirstName == null || ind.FirstName.ToLower().Contains((request.FirstName ?? string.Empty).ToLower()))
                                 && (ind.LastName == null || ind.LastName.ToLower().Contains((request.LastName ?? string.Empty).ToLower()))
                                 && (ind.MiddleName == null || ind.MiddleName.ToLower().Contains((request.MiddleName ?? string.Empty).ToLower()))
                                 && (ar.ArticleNumber == null || ar.ArticleNumber.ToLower().Contains((request.ArticleNumber ?? string.Empty).ToLower()))
                                 && (request.CourtSentenceNumber == null || c.CourtSentenceNumber.ToLower().Contains((request.CourtSentenceNumber ?? string.Empty).ToLower()))
                           select new UserIndividualViewModel
                           {
                               FirstName = ind.FirstName,
                               LastName = ind.LastName,
                               MiddleName = ind.MiddleName,
                               WorkPosition = ind.WorkPosition,
                               Workplace = ind.Workplace,
                               OffenceDescription = cr.OffenceDescription,
                               ArticleNumber = ar.ArticleNumber,
                               ArticleTitle = ar.ArticleTitle,
                               ArticleContent = ar.ArticleContent,
                               CourtName = c.CourtName,
                               CourtCaseNumber = c.CourtCaseNumber,
                               CourtSentenceDate = c.CourtSentenceDate,
                               CourtSentenceNumber = c.CourtSentenceNumber,
                               CourtSentenceApplyingDate = c.CourtSentenceApplyingDate,
                               DisciplinaryActionDetails = p.DisciplinaryActionDetails,
                               IsActive = c.IsActive.Value.ToString()
                           };
            return response.ToList();
        }

        public List<EditorIndividualViewModel> GetEditorIndividualData(GetIndividualRequest request)
        {
            var response = from ind in _context.IndividualData
                           join pcco in _context.Pccos on ind.Id equals pcco.IndividualDataId
                           join c in _context.CorruptionRecords on pcco.CorruptionRecordId equals c.Id
                           join cr in _context.CrimeInfos on c.CrimeInfoId equals cr.Id
                           join p in _context.Punishments on c.PunishmentId equals p.Id
                           join ar in _context.CriminalArticles on p.CriminalArticleId equals ar.Id
                           join ia in _context.IssuingAuthorities on ind.IssuingAuthorityId equals ia.Id
                           where (ind.FirstName == null || ind.FirstName.ToLower().Contains((request.FirstName ?? string.Empty).ToLower()))
                                 && (ind.LastName == null || ind.LastName.ToLower().Contains((request.LastName ?? string.Empty).ToLower()))
                                 && (ind.MiddleName == null || ind.MiddleName.ToLower().Contains((request.MiddleName ?? string.Empty).ToLower()))
                                 && (ar.ArticleNumber == null || ar.ArticleNumber.ToLower().Contains((request.ArticleNumber ?? string.Empty).ToLower()))
                                 && (request.CourtSentenceNumber == null || c.CourtSentenceNumber.ToLower().Contains((request.CourtSentenceNumber ?? string.Empty).ToLower()))
                           select new EditorIndividualViewModel
                           {
                               IdIndividual = ind.Id,
                               IdPcco = pcco.Id,
                               FirstName = ind.FirstName,
                               LastName = ind.LastName,
                               MiddleName = ind.MiddleName,
                               IdentificationCode = ind.IdentificationCode,
                               WorkPosition = ind.WorkPosition,
                               Workplace = ind.Workplace,
                               Birthday = ind.Birthday,
                               Birthplace = ind.Birthplace,
                               Residence = ind.Residence,
                               Series = ind.Series,
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
                               OffenceLocation = cr.OffenceLocation,
                               Code = ia.Code,
                               UnitName = ia.UnitName,
                               DepartmentName = ia.DepartmentName,
                               PostalCode = ia.PostalCode,
                               City = ia.City,
                               Street = ia.Street,
                               BuildingNumber = ia.BuildingNumber
                           };
            return response.ToList();
        }

        public EditorIndividualViewModel GetEditorIndividualDataById(int id)
        {
            var response = from ind in _context.IndividualData
                           join pcco in _context.Pccos on ind.Id equals pcco.IndividualDataId
                           join c in _context.CorruptionRecords on pcco.CorruptionRecordId equals c.Id
                           join cr in _context.CrimeInfos on c.CrimeInfoId equals cr.Id
                           join p in _context.Punishments on c.PunishmentId equals p.Id
                           join ar in _context.CriminalArticles on p.CriminalArticleId equals ar.Id
                           join ia in _context.IssuingAuthorities on ind.IssuingAuthorityId equals ia.Id
                           where (id == ind.Id)
                           select new EditorIndividualViewModel
                           {
                               IdIndividual = ind.Id,
                               IdPcco = pcco.Id,
                               FirstName = ind.FirstName,
                               LastName = ind.LastName,
                               MiddleName = ind.MiddleName,
                               IdentificationCode = ind.IdentificationCode,
                               WorkPosition = ind.WorkPosition,
                               Workplace = ind.Workplace,
                               Birthday = ind.Birthday,
                               Birthplace = ind.Birthplace,
                               Residence = ind.Residence,
                               Series = ind.Series,
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
                               OffenceLocation = cr.OffenceLocation,
                               Code = ia.Code,
                               UnitName = ia.UnitName,
                               DepartmentName = ia.DepartmentName,
                               PostalCode = ia.PostalCode,
                               City = ia.City,
                               Street = ia.Street,
                               BuildingNumber = ia.BuildingNumber
                           };
            return response.FirstOrDefault();
        }

        public void AddIndividual(EditorIndividualViewModel model)
        {
            var issuingAuthority = new IssuingAuthority
            {
                Code = model.Code,
                UnitName = model.UnitName,
                DepartmentName = model.DepartmentName,
                PostalCode = model.PostalCode,
                City = model.City,
                Street = model.Street,
                BuildingNumber = model.BuildingNumber
            };

            _context.Add(issuingAuthority);

            var individualData = new IndividualData
            {
                IssuingAuthority = issuingAuthority,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                IdentificationCode = model.IdentificationCode,
                WorkPosition = model.WorkPosition,
                Workplace = model.Workplace,
                Birthday = model.Birthday.Value,
                Birthplace = model.Birthplace,
                Residence = model.Residence,
                Series = model.Series
            };
            _context.Add(individualData);

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

            var pcco = new Pcco { IsIndividual = true, CorruptionRecord = corruptionRecord, IndividualData = individualData, LegalEntityData = null };
            _context.Add(pcco);
        }

        public void EditIndividual(EditorIndividualViewModel model)
        {
            var pcco = _context.Pccos.Find(model.IdPcco);

            if (pcco == null)
                throw new Exception("No individual entity with such id"); ;

            var corruptionRecord = _context.CorruptionRecords.Find(pcco.CorruptionRecordId);
            var crimeInfo = _context.CrimeInfos.Find(corruptionRecord.CrimeInfoId);
            var punishment = _context.Punishments.Find(corruptionRecord.PunishmentId);
            var criminalArticle = _context.CriminalArticles.Find(punishment.CriminalArticleId);
            var individualData = _context.IndividualData.Find(pcco.IndividualDataId);
            var issuingAuthority = _context.IssuingAuthorities.Find(individualData.IssuingAuthorityId);

            issuingAuthority.BuildingNumber = model.BuildingNumber;
            issuingAuthority.City = model.City;
            issuingAuthority.Code = model.Code;
            issuingAuthority.DepartmentName = model.DepartmentName;
            issuingAuthority.PostalCode = model.PostalCode;
            issuingAuthority.Street = model.Street;
            issuingAuthority.UnitName = model.UnitName;

            individualData.FirstName = model.FirstName;
            individualData.LastName = model.LastName;
            individualData.MiddleName = model.MiddleName;
            individualData.IdentificationCode = model.IdentificationCode;
            individualData.WorkPosition = model.WorkPosition;
            individualData.IssuingAuthority = issuingAuthority;
            individualData.Workplace = model.Workplace;
            individualData.Birthday = model.Birthday.Value;
            individualData.Birthplace = model.Birthplace;
            individualData.Residence = model.Residence;
            individualData.Series = model.Series;

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

            pcco.IsIndividual = true;
            pcco.CorruptionRecord = corruptionRecord;
            pcco.IndividualData = individualData;
        }

        public string[] GetArticles()
        {
            var ret = _context.CriminalArticles.Select(x => x.ArticleNumber).Distinct().ToArray();
            return ret;
        }
    }
}