using HH.RMS.Common.Constant;
using HH.RMS.Service.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web.Interface
{
    public interface IEmailService
    {
        ResultType InsertEmail(EmailModel model);
        EmailModel QueryEmailById(long id);
        ResultType InsertEmailLog(EmailLogModel model);
        ResultType SendEmail(EmailLogModel model);
    }
}
