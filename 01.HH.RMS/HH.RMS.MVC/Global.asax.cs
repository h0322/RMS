using HH.RMS.Common.Constant;
using HH.RMS.Entity.Web;
using HH.RMS.MVC;
using HH.RMS.Scheduler;
using HH.RMS.Service.Web;
using HH.RMS.Common.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using HH.RMS.MVC.App_Start;

namespace HH.RMS.MVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Application_Start()
        {
            Log4NetConfig.Register(this);
            AreaRegistration.RegisterAllAreas();
            new ServiceConfig(UnityManager.instance);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    var ex = Server.GetLastError().GetBaseException();
        //    Config.log.Error("Application.Error:"+Request.Url, ex);
        //    //Response.Redirect("/Error.html");
        //}
    }
}