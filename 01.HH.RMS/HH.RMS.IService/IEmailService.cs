using HH.RMS.Common.Constant;
using HH.RMS.IService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService
{
    public interface IEmailService
    {
        ResultType InsertEmail(EmailModel model);
        EmailModel QueryEmailById(long id);
        ResultType InsertEmailLog(EmailLogModel model);
        ResultType SendEmail(EmailLogModel model);
    }
}
