using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.MVC.Models;
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
        protected override bool AuthorizeCore(HttpContextBase context)
        {
            if (SessionHelper.GetSession(Config.loginSession) == null)
            {
                return false;
            }
            return true;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            string currentUrl = filterContext.HttpContext.Request.Url.ToString();
            if (SessionHelper.GetSession(Config.loginSession) == null)
            {
                filterContext.Result = new RedirectResult("/Login/Index?RedirectUrl=" + HttpUtility.UrlEncode(currentUrl));
                return;
            }
            
        }  

    }
}