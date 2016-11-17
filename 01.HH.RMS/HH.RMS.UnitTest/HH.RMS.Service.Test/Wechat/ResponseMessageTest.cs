using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HH.RMS.Service.Wechat.Interface;
using HH.RMS.Service.Wechat;

namespace HH.RMS.UnitTest.HH.RMS.Service.Test.Wechat
{
    [TestClass]
    public class ResponseMessageTest
    {
        [TestMethod]
        public void Manager()
        {
            string postString = "<xml><ToUserName><![CDATA[gh_f9717ac9e758]]></ToUserName> <FromUserName><![CDATA[o2Xz5s7gsaUAVuk_lte_iOPdDPwk]]></FromUserName> <CreateTime>1467876889</CreateTime> <MsgType><![CDATA[text]]></MsgType> <Content><![CDATA[明星产品]]></Content> <MsgId>6304483233223097116</MsgId> </xml>";
            IResponseMessageService ms = new ResponseMessageService();
            ms.Manager(postString);
        }
    }
}
