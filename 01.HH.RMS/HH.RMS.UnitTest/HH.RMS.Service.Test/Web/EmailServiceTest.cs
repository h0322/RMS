using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HH.RMS.Service.Web.Interface;
using HH.RMS.Common.Constant;
using HH.RMS.Service.Web.Model;
using HH.RMS.Common.Unity;

namespace HH.RMS.UnitTest.HH.RMS.Service.Test.Web
{
    [TestClass]
    public class EmailServiceTest : TestServiceBase
    {
        private IEmailService _emailService { get; set; }
        public EmailServiceTest()
        {
            _emailService = UnityManager.instance.GetService<IEmailService>();
            ServiceLogin();
        }
        [TestMethod]
        public void InsertEmail()
        {
            EmailModel model = new EmailModel();
            model.name="忘记密码邮件";
            model.description="";
            model.emailSubject = "忘记密码邮件";
            model.emailBody = "你好{0}:<br/>您的密码修改为{1},登录后立即修改新的密码";
            var result = _emailService.InsertEmail(model);
            Assert.AreEqual(result, ResultType.Success);
        }
    }
}
