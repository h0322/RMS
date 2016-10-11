using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Common.Utilities;
using HH.RMS.MVC.Models;
using HH.RMS.Service.Web.Interface;
using System.Web;
using System.Web.Mvc;

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
        public new string[] RoleType { }
        protected override bool AuthorizeCore(HttpContextBase context)
        {
            if (SessionHelper.GetSession(Config.loginSession) == null)
            {
                return false;
            }
            return true;
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
            
        }  

    }
}