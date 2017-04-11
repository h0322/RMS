using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HH.RMS.Common.Unity;
using HH.RMS.Common.Constant;
using System.Web;
using HH.RMS.Common.Utilities;
using HH.RMS.IService;
using HH.RMS.IService.Model;

namespace HH.RMS.UnitTest.HH.RMS.Service.Test.Web
{
    [TestClass]
    public class AccountServiceTest:TestServiceBase
    {
        private IAccountService _accountService { get; set; }
        private long accountId = 2;
        public AccountServiceTest()
        {
            _accountService = UnityManager.instance.GetService<IAccountService>();
            ServiceLogin();
        }
        [TestMethod]
        public void QueryAccountById()
        {
            //for(int i=0;i<10000;i++)
            //{

                AccountModel accountModel = _accountService.QueryAccountById(accountId);
            //}
            
            //Assert.AreNotEqual(accountModel, null);
        }
        [TestMethod]
        public void InsertAccount()
        {
            AccountModel account = new AccountModel();
            account.accountName=DateTime.Now.Ticks.ToString()+"_test";
            account.password = "123456";
            account.amount=0;
            //account.birthday = "1970-01-01";
            account.cityId=1;
            account.countryId=1;
            account.createBy=0;
            account.createTime=DateTime.Now;
            account.email="test@test.com";
            account.levelId=1;
            account.provinceId=1;
            account.roleBitMap = 1;
            account.status = AccountStatusType.Normal;
            ResultType resultType = _accountService.InsertAccount(account);
            Assert.AreEqual(resultType, ResultType.Success);
        }

        //[TestMethod]
        //public void UpdateAccount()
        //{
        //    AccountModel account = new AccountModel();
        //    account.id = 38;
        //    account.accountName = Guid.NewGuid().ToString() + "_test";
        //    account.amount = 0;
        //    account.accountType = AccountType.Admin;
        //    account.roleBitMap = 1;
        //    account.birthday = "1970-01-01";
        //    account.cityId = 1;
        //    account.countryId = 1;
        //    account.createBy = 0;
        //    account.createTime = DateTime.Now;
        //    account.email = "test@test.com";
        //    account.levelId = 1;
        //    account.personId = 1;
        //    account.provinceId = 1;
        //    account.status = AccountStatusType.Normal;
        //    account.personId = 9;
        //    ResultType resultType = _accountService.UpdateAccount(account);
        //    Assert.AreEqual(resultType, ResultType.Success);
        //}
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
            int result = _accountService.CountAccount();
            Assert.AreNotEqual(result, 0);
        }
        [TestMethod]
        public void ResetPassword()
        { }
    }
}
