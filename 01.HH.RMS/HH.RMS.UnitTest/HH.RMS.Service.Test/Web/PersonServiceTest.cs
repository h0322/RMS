using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HH.RMS.Service.Web.Interface;
using HH.RMS.Common.Unity;
using HH.RMS.Service.Web.Model;
using HH.RMS.Service.Model;
using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;

namespace HH.RMS.UnitTest.HH.RMS.Service.Test.Web
{
    [TestClass]
    public class PersonServiceTest : TestServiceBase
    {
        private IAccountService _accountService { get; set; }
        private ILoginService _loginService { get; set; }
        private IPersonService _personService { get; set; }

        public PersonServiceTest()
        {
            _accountService = UnityManager.instance.GetService<IAccountService>();
            _personService = UnityManager.instance.GetService<IPersonService>();
            Login();
        }
        [TestMethod]
        public void QueryPersonToGrid()
        {
            Assert.AreNotEqual(_personService.QueryPersonToGrid(), null);
        }
        [TestMethod]
        public void QueryPersonById()
        {
            Assert.AreNotEqual(_personService.QueryPersonById(1), null);
        }
        [TestMethod]
        public void CreatePersonAccount()
        { 
        }
        [TestMethod]
        public void UpdatePersonById()
        {
           // Assert.AreNotEqual(_personService.QueryPersonById(1), null);
        }
    }
}
