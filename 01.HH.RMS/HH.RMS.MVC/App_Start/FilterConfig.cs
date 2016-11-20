using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Common.Utilities;
using HH.RMS.MVC.Models;
using HH.RMS.Service.Web.Interface;
using HH.RMS.Service.Web.Model;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Linq.Expressions;

namespace HH.RMS.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
       
    }
    public class RMSAuthorizeAttribute : AuthorizeAttribute
    {
        public new int excuteType { get; set; }
        public new string menuCode { get; set; }
        protected override bool AuthorizeCore(HttpContextBase context)
        {
            if (SessionHelper.GetSession(Config.loginSession) == null)
            {
                return false;
            }
            return CheckRole();
            //return base.AuthorizeCore(context);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            string currentUrl = filterContext.HttpContext.Request.Url.ToString();
            if (SessionHelper.GetSession(Config.loginSession) == null)
            {
                UnityManager.instance.GetService<ILoginService>().ExitLogin();
                filterContext.Result = new RedirectResult("/Login/Index?RedirectUrl=" + HttpUtility.UrlEncode(currentUrl));
                return;
            }
            filterContext.Result = new JsonResult() { Data = new { access = ResultType.NoAccess } };
            
        }
        private bool CheckRole()
        {
            if (AccountModel.CurrentSession.accountType == AccountType.Admin)
            {
                return true;
            }
            if (excuteType > 0 && !string.IsNullOrEmpty(menuCode))
            {
                MenuRoleModel role = MenuRoleModel.ListSession.Where(m => m.code == menuCode && ((int)m.excuteType & excuteType) == excuteType).FirstOrDefault();
                if (role == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }

    }
}