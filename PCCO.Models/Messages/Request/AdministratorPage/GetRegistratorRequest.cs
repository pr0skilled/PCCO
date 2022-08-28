using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCO.Models.Messages.Request.AdministratorPage
{
    public class GetRegistratorRequest
    {
        public string LastName { get; set; }
        public string IdentificationCode { get; set; }
    }
}
