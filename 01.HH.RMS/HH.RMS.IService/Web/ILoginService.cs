using HH.RMS.Common.Constant;
using HH.RMS.Common.Model;
using HH.RMS.IService.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService.Web
{
    public interface ILoginService
    {
        ResultModel<AccountModel> UserLogin(string accountName, string password);
        void ExitLogin();
        ResultModel<ResultType> ForgetPassword(AccountModel model);
    }
}
