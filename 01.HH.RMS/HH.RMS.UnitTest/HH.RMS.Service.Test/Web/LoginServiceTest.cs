using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HH.RMS.Service.Web.Interface;
using HH.RMS.Common.Unity;
using HH.RMS.Service.Web.Model;
using HH.RMS.Common.Constant;
using System.Web;
using HH.RMS.Service.Model;
using HH.RMS.Common.Utilities;

namespace HH.RMS.UnitTest.HH.RMS.Service.Test.Web
{
    [TestClass]
    public class LoginServiceTest:TestServiceBase
    {
        private ILoginService _loginService { get; set; }
        public LoginServiceTest()
        {
            _loginService = UnityManager.instance.GetService<ILoginService>();
            ServiceLogin();
        }
        [TestMethod]

        public void Login()
        {
            var loginResult = _loginService.UserLogin(loginName, password);
            Assert.AreEqual(loginResult.resultType, ResultType.Success);
        }

    }
}
