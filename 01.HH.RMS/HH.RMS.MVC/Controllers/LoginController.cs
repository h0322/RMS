using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Service.Web.Model;
using HH.RMS.MVC.Models;
using HH.RMS.Service.Web;
using HH.RMS.Service.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HH.RMS.Service.Model;
using HH.RMS.Service;
using System.Threading;

namespace HH.RMS.MVC.Controllers
{
    public class LoginController : ControllerService
    {
        //
        // GET: /Login/
        private ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public ActionResult Index(string redirectUrl)
        {
            LoginModel model = new LoginModel();
            _log.Info(21);
            Thread.Sleep(10000);  
            model.redirectUrl = redirectUrl;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Index(LoginModel model)
        {
            _log.Info(31);
            Thread.Sleep(10000);  
            ResultModel<AccountModel> result = _loginService.UserLogin(model.accountName, model.password);
            if (result.resultType == ResultType.Success)
            {
                if (result.resultObj.statusType == AccountStatusType.Normal)
                {
                    FormsAuthentication.SetAuthCookie(result.resultObj.accountName, true);
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket
                   (1,
                       result.resultObj.accountName,
                       DateTime.Now,
                       DateTime.Now.AddMinutes(20),
                       true,
                       result.resultObj.role.roleId.ToString(),
                       "/"
                   );
                    SessionHelper.SetSession(Config.loginSession, result.resultObj);
                    return Json(new { msg = ResultType.Success });
                }
            }
            return Json(new { msg = ResultType.Fail });
        }



        public ActionResult Exit()
        {
            _loginService.ExitLogin();
            return Redirect("/Login/Index");
        }
    }
}
