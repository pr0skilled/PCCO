using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PCCO.Models.ViewModels;

namespace PCCO.Models.Messages.Response.RegistratorPage
{
    public class RegistratorGetLegalResponse : ResponseBase
    {
        public List<EditorLegalViewModel> Data { get; set; }
    }
}
