using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HH.RMS.Service.Wechat.Interface;
using HH.RMS.Common.Unity;

namespace HH.RMS.UnitTest.HH.RMS.Service.Test.Wechat
{
    [TestClass]
    public class WechatUserTest:TestServiceBase
    {
        private IWechatUserService _wechatUserService { get; set; }
        public WechatUserTest()
        {
            _wechatUserService = UnityManager.instance.GetService<IWechatUserService>();
        }
        [TestMethod]
        public void GetWechatUserByOpenId()
        {
            Assert.AreNotEqual(_wechatUserService.GetWechatUserByOpenId("o2Xz5s7gsaUAVuk_lte_iOPdDPwk"),null);
        }
    }
}
