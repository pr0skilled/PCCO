using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PCCO.Models;
using PCCO.Models.ViewModels;

namespace PCCO.Models.Messages.Response.RegistratorPage
{
    public class RegistratorGetIndividualResponse : ResponseBase
    {
        public List<EditorIndividualViewModel> Data { get; set; }
    }
}
