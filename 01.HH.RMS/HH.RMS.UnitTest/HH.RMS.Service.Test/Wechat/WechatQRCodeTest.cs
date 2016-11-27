﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HH.RMS.Service.Wechat.Interface;
using HH.RMS.Common.Unity;

namespace HH.RMS.UnitTest.HH.RMS.Service.Test.Wechat
{
    [TestClass]
    public class WechatQRCodeTest : TestServiceBase
    {
        private IWechatQRCodeService _wechatQRCodeService { get; set; }
        public WechatQRCodeTest()
        {
            _wechatQRCodeService = UnityManager.instance.GetService<IWechatQRCodeService>();
        }
        [TestMethod]
        public void GetQRCodeUrl()
        {
            _wechatQRCodeService.GetQRCodeUrl();
        }
    }
}