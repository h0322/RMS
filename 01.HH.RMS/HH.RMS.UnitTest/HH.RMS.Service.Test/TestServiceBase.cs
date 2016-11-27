using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Common.Utilities;
using HH.RMS.Service;
using HH.RMS.Service.Model;
using HH.RMS.Service.Web.Interface;
using HH.RMS.Service.Web.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace HH.RMS.UnitTest.HH.RMS.Service.Test
{
    public class TestServiceBase
    {
        protected string loginName = "admin";
        protected string password = "e10adc3949ba59abbe56e057f20f883e";
        private ILoginService _loginService { get; set; }
        public TestServiceBase()
        {
            new UnityService(UnityManager.instance);
            HttpCurrent();
        }
        public static void HttpCurrent()
        {
            var httpRequest = new HttpRequest("", "http://localhost:8888/", "");
            var stringWriter = new StringWriter();
            var httpResponce = new HttpResponse(stringWriter);
            var httpContext = new HttpContext(httpRequest, httpResponce);

            var sessionContainer = new HttpSessionStateContainer("id", new SessionStateItemCollection(),
                                                                 new HttpStaticObjectsCollection(), 10, true,
                                                                 HttpCookieMode.AutoDetect,
                                                                 SessionStateMode.InProc, false);

            httpContext.Items["AspSession"] = typeof(HttpSessionState).GetConstructor(
                                                     BindingFlags.NonPublic | BindingFlags.Instance,
                                                     null, CallingConventions.Standard,
                                                     new[] { typeof(HttpSessionStateContainer) },
                                                     null)
                                                .Invoke(new object[] { sessionContainer });
            HttpContext.Current = httpContext;
        }
        public virtual void ServiceLogin()
        {
            _loginService = UnityManager.instance.GetService<ILoginService>();
            var result = _loginService.UserLogin(loginName, password);
            SessionHelper.SetSession(Config.loginSession, result.resultObj);
        }
    }
}
