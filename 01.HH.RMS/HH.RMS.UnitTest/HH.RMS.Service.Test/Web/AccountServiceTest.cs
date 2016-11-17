using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HH.RMS.Service.Web.Interface;
using HH.RMS.Common.Unity;
using HH.RMS.Service.Web.Model;
using HH.RMS.Common.Constant;

namespace HH.RMS.UnitTest.HH.RMS.Service.Test.Web
{
    [TestClass]
    public class AccountServiceTest:TestServiceBase
    {
        IAccountService accountService { get; set; }
        private long accountId = 2;
        public AccountServiceTest()
        {
            accountService = UnityManager.instance.GetService<IAccountService>();
        }
        [TestMethod]
        public void QueryAccountById()
        {
            AccountModel accountModel = accountService.QueryAccountById(accountId);
            Assert.AreNotEqual(accountModel, null);
        }
        [TestMethod]
        public void InsertAccount()
        {
            AccountModel account = new AccountModel();
            account.accountName=DateTime.Now.Ticks.ToString()+"_test";
            account.password = "123456";
            account.amount=0;
            account.birthday = "1970-01-01";
            account.cityId=1;
            account.countryId=1;
            account.createBy=0;
            account.createTime=DateTime.Now;
            account.email="test@test.com";
            account.levelId=1;
            account.personId=1;
            account.provinceId=1;
            account.roleBitMap = 1;
            account.status = AccountStatusType.Normal;
            ResultType resultType = accountService.InsertAccount(account);
            Assert.AreEqual(resultType, ResultType.Success);
        }
        [TestMethod]
        public void QueryAccountToGridByRole()
        {
            var result = accountService.QueryAccountToGridByRole();
            Assert.AreNotEqual(result, null);
        }
        [TestMethod]
        public void UpdateAccount()
        {
            AccountModel account = new AccountModel();
            account.accountName = Guid.NewGuid().ToString() + "_test";
            account.amount = 0;
            account.birthday = "1970-01-01";
            account.cityId = 1;
            account.countryId = 1;
            account.createBy = 0;
            account.createTime = DateTime.Now;
            account.email = "test@test.com";
            account.levelId = 1;
            account.personId = 1;
            account.provinceId = 1;
            account.status = AccountStatusType.Normal;
            account.personId = 9;
            ResultType resultType = accountService.UpdateAccount(account);
            Assert.AreEqual(resultType, ResultType.Success);
        }
        [TestMethod]
        public void DeleteAccountById()
        { 
        }
        [TestMethod]
        public void DeleteAccountMassById()
        {
        }
        [TestMethod]
        public void CountAccount()
        {
            int result = accountService.CountAccount();
            Assert.AreNotEqual(result, 0);
        }
    }
}
