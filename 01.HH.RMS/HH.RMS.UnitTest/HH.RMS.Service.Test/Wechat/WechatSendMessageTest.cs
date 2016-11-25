using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HH.RMS.Service.Wechat.Model;
using HH.RMS.Common.Utilities;
using HH.RMS.Common.Constant;
using HH.RMS.Service.Wechat;
using HH.RMS.Common.Unity;
using HH.RMS.Service.Wechat.Interface;
using HH.RMS.Wechat.Model;

namespace HH.RMS.UnitTest.HH.RMS.Service.Test.Wechat
{
    [TestClass]
    public class WechatSendMessageTest : TestServiceBase
    {
        private IWechatRequestService _wechatRequestModel { get; set; }
        public WechatSendMessageTest()
        {
            _wechatRequestModel = UnityManager.instance.GetService<IWechatRequestService>();
        }
        [TestMethod]
        public void WechatMsgMass()
        {
            WechatMsgMassTextModel model = new WechatMsgMassTextModel();
            model.text = new WechatMsgMassTextDetailModel() { content="test"};
            model.msgType = "text";
            model.touser = new string[] { "o2Xz5s_Q4DR6hkgUTDzrzlgh_j7Y", "o2Xz5s7gsaUAVuk_lte_iOPdDPwk" };
            WechatRequestModel request = new WechatRequestModel(){ data= model.ToString(), url=string.Format(Config.sendMsgMassByOpenidUrl,AccessTokenModel.CurrentCache.accessToken)};
            var result = _wechatRequestModel.PostData(request);
            Assert.AreEqual(result.resultType, ResultType.Success);
        }
    }
}
