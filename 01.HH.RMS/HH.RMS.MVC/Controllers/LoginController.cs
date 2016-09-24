using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Service.Model;
using HH.RMS.MVC.Models;
using HH.RMS.Service;
using HH.RMS.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
            model.redirectUrl = redirectUrl;
            return View(model);
        }

        [HttpPost]
        public JsonResult Index(LoginModel model)
        {

            ResultModel<AccountModel> result = _loginService.UserLogin(model.accountName, model.password);
            if (result.resultType == ResultType.Success)
            {
                if (result.resultObj.statusType == AccountStatusType.Normal)
                {
                    FormsAuthentication.SetAuthCookie(result.resultObj.accountName.ToString(), true);
                    SessionHelper.SetSession(Config.loginSession, result.resultObj);
                    return Json(new { msg = ResultType.Success });
                }
            }
            return Json(new { msg = ResultType.Fail });
        }



        public ActionResult Exit()
        {
            _loginService.ExitLogin();
            return View();
        }
    }
}
