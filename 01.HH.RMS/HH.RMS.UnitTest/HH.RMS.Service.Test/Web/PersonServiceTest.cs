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
        private IPersonService _personService { get; set; }

        public PersonServiceTest()
        {
            _personService = UnityManager.instance.GetService<IPersonService>();
            ServiceLogin();
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
            AccountModel account = new AccountModel();
            account.accountName = Guid.NewGuid().ToString() + "_test";
            account.password = "123456";
            account.amount = 0;
            account.accountType = AccountType.Admin;
            account.roleBitMap = 1;
            account.birthday = "1970-01-01";
            account.cityId = 1;
            account.countryId = 1;
            account.createBy = 0;
            account.createTime = DateTime.Now;
            account.email = "test@test.com";
            account.levelId = 1;
            account.provinceId = 1;
            account.status = AccountStatusType.Normal;
            var result = _personService.CreatePersonAccount(account);
            Assert.AreEqual(result.resultType, ResultType.Success);
        }
        [TestMethod]
        public void UpdatePersonById()
        {
            PersonModel person = new PersonModel();
            person.birthday = "1970-01-01";
            person.cityId = 1;
            person.countryId = 1;
            person.provinceId = 1;
            person.sex = SexType.Female;
            person.id = 18;
            var result = _personService.UpdatePersonById(person);
            Assert.AreEqual(result, ResultType.Success);
           // Assert.AreNotEqual(_personService.QueryPersonById(1), null);
        }
    }
}
