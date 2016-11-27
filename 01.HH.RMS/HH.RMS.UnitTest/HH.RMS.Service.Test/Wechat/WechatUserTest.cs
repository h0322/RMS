using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HH.RMS.Service.Wechat.Interface;
using HH.RMS.Common.Unity;
using HH.RMS.Service.Wechat.Model;
using System.Collections.Generic;

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
            WechatUserRequestModel requestModel = new WechatUserRequestModel() { openId = "o2Xz5s_Q4DR6hkgUTDzrzlgh_j7Y", lang = "zh_CN" };
            Assert.AreNotEqual(_wechatUserService.GetWechatUserByOpenId(requestModel), null);
        }
        [TestMethod]
        public void BatchGetWechatUserByOpenId()
        {
            List<WechatUserRequestModel> list = new List<WechatUserRequestModel>();
            WechatUserRequestModel model = new WechatUserRequestModel();
            model.openId = "o2Xz5s39RATQkzmQ1unzWDK1hmcg";
            model.lang = "zh_CN";
            list.Add(model);
            model = new WechatUserRequestModel();
            model.openId = "o2Xz5sw27OhNGI40I1pOrVBDgGho";
            model.lang = "zh_CN";
            list.Add(model);
            Assert.AreNotEqual(_wechatUserService.BatchGetWechatUserByOpenId(list), null);
        }
        [TestMethod]
        public void GetWechatOpenIdList()
        {
            Assert.AreNotEqual(_wechatUserService.GetWechatOpenIdList(), null);
        }
    }
}
