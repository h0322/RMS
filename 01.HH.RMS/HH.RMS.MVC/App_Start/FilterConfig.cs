using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Common.Utilities;
using HH.RMS.MVC.Models;
using HH.RMS.IService.Web;
using HH.RMS.IService.Web.Model;
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
            filters.Add(new RMSException());
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
            return base.AuthorizeCore(context);
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;
            if (!CheckRole(controllerName, actionName))
            {
                HandleUnauthorizedRequest(filterContext);
                return;
            }
            base.OnAuthorization(filterContext);
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
        private bool CheckRole(string controller,string action)
        {
            if (excuteType == 0 )
            {
                return true;
            }
            if (AccountModel.CurrentSession.accountType == AccountType.Admin)
            {
                return true;
            }
            MenuModel menu = null;
            switch (excuteType)
            {
                case (int)ExcuteType.Insert:
                    menu = MenuModel.CurrentCacheList.Where(m => m.code == controller && (m.insertBitMap & AccountModel.CurrentSession.roleBitMap) == AccountModel.CurrentSession.roleBitMap).FirstOrDefault();
                    break;
                case (int)ExcuteType.Update:
                    menu = MenuModel.CurrentCacheList.Where(m => m.code == controller && (m.updateBitMap & AccountModel.CurrentSession.roleBitMap) == AccountModel.CurrentSession.roleBitMap).FirstOrDefault();
                    break;
                case (int)ExcuteType.Select:
                    menu = MenuModel.CurrentCacheList.Where(m => m.code == controller && (m.selectBitMap & AccountModel.CurrentSession.roleBitMap) == AccountModel.CurrentSession.roleBitMap).FirstOrDefault();
                    break;
                case (int)ExcuteType.Delete:
                    menu = MenuModel.CurrentCacheList.Where(m => m.code == controller && (m.deleteBitMap & AccountModel.CurrentSession.roleBitMap) == AccountModel.CurrentSession.roleBitMap).FirstOrDefault();
                    break;
            }
            if (menu == null)
            {
                return false;
            }
            return true;
        }

    }
    public class RMSException : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                filterContext.ExceptionHandled = true;
                //filterContext.HttpContext.Response.Write(filterContext.Exception.ToString());
            }
            base.OnException(filterContext);
        }
    }
    public class RMSActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }

    }
}