﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HH.RMS.Common.Unity;
using HH.RMS.Service.Web.Interface;
using HH.RMS.Service.Web.Model;
using HH.RMS.Common.Constant;

namespace HH.RMS.UnitTest.HH.RMS.Service.Test.Web
{
    [TestClass]
    public class CollcetServiceTest : TestServiceBase
    {
        private ICollcetService _collectService { get; set; }
        public CollcetServiceTest()
        {
            _collectService = UnityManager.instance.GetService<ICollcetService>();
        }
        [TestMethod]
        public void CollcetMessage()
        {
            CollectModel model = new CollectModel();
            model.url="http://www.baidu.com";
            ResultType result = _collectService.CollcetMessage(model);
        }
    }
}