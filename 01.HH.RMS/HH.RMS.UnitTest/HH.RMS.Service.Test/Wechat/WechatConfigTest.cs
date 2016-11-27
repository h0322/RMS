using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HH.RMS.Service.Wechat.Interface;
using HH.RMS.Common.Unity;
using HH.RMS.Common.Constant;

namespace HH.RMS.UnitTest.HH.RMS.Service.Test.Wechat
{
    [TestClass]
    public class WechatConfigTest : TestServiceBase
    {
        private IWechatConfigService _wechatConfigService { get; set; }
        public WechatConfigTest()
        {
            _wechatConfigService = UnityManager.instance.GetService<IWechatConfigService>();
        }
        [TestMethod]
        public void QueryWechatConfig()
        {
            var model = _wechatConfigService.QueryWechatConfig();
            Assert.AreNotEqual(model, null);
        }
         [TestMethod]
        public void GetAccessToken()
        {
            var result = _wechatConfigService.GetAccessToken();
            Assert.AreEqual(result.resultType, ResultType.Success);
        }
    }
}
