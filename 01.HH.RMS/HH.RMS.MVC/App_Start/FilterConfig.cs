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
                string currentUrl = context.Request.Url.ToString();
                context.Response.Redirect("/Login/Index?RedirectUrl=" + HttpUtility.UrlEncode(currentUrl));
            }
            return base.AuthorizeCore(context);
        }

    }
}