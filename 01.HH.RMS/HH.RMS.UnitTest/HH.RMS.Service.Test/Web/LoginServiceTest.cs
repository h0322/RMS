using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HH.RMS.Service.Web.Interface;
using HH.RMS.Service.Web;
using HH.RMS.Common.Unity;
using HH.RMS.Service;
using HH.RMS.Service.Model;
using HH.RMS.Service.Web.Model;
using HH.RMS.Common.Constant;

namespace HH.RMS.UnitTest.HH.RMS.Service.Test.Web
{
    [TestClass]
    public class LoginServiceTest : TestServiceBase
    {
        public LoginServiceTest()
        {
 
        }
        [TestMethod]
        public void Login()
        {
            string loginName = "admin";
            string password = "123456";
            ILoginService loginService = UnityManager.instance.GetService<ILoginService>();
            ResultModel<AccountModel> loginResult = loginService.UserLogin(loginName, password);
            Assert.AreEqual(loginResult.resultType, ResultType.Success);
        }
    }
}
