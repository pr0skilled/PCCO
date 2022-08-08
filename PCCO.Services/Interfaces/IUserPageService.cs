using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PCCO.Models.Messages.Request.UserPage;
using PCCO.Models.Messages.Response.UserPage;
using PCCO.Models.ViewModels;

namespace PCCO.Services.Interfaces
{
    public interface IUserPageService
    {
        public UserGetIndividualResponse GetIndividuals(GetIndividualRequest request);
        public UserGetLegalResponse GetLegals(GetLegalRequest request);
        public string[] GetArticles();
    }
}
