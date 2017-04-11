using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HH.RMS.Common.Unity;
using HH.RMS.Common.Constant;
using System.Web;
using HH.RMS.Common.Utilities;
using HH.RMS.IService.Model;
using HH.RMS.IService;

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
        [TestMethod]
        public void ForgetPassword()
        {
            AccountModel model=new AccountModel();
            model.accountName = "admin";
            var result = _loginService.ForgetPassword(model);
            Assert.AreEqual(result.resultType, ResultType.Success);
        }


    }
}
