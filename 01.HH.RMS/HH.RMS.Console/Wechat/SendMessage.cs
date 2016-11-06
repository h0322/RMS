using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HH.RMS.Wechat;
using HH.RMS.Wechat.Message;
using HH.RMS.Wechat.Model;

namespace HH.RMS.Console.Wechat
{
    public class SendMessage
    {
        public SendMessage()
        {
            //string postString = "<xml><ToUserName><![CDATA[gh_f9717ac9e758]]></ToUserName> <FromUserName><![CDATA[o2Xz5s7gsaUAVuk_lte_iOPdDPwk]]></FromUserName> <CreateTime>1467876889</CreateTime> <MsgType><![CDATA[text]]></MsgType> <Content><![CDATA[明星产品]]></Content> <MsgId>6304483233223097116</MsgId> </xml>";
            //MessageManager.instance.Manager(postString);

        }

        

    }
    public class SendMessageDefine :MessageManager
    {
        public SendMessageDefine()
        {
            string postString = "<xml><ToUserName><![CDATA[gh_f9717ac9e758]]></ToUserName> <FromUserName><![CDATA[o2Xz5s7gsaUAVuk_lte_iOPdDPwk]]></FromUserName> <CreateTime>1467876889</CreateTime> <MsgType><![CDATA[text]]></MsgType> <Content><![CDATA[明星产品]]></Content> <MsgId>6304483233223097116</MsgId> </xml>";
            Manager(postString);
        }
        public override void ProcessMsg(BaseProcess processMsg, WechatPostModel postModel)
        {
            if (postModel.msgType == "text")
            {
                return;
            }
            base.ProcessMsg(processMsg, postModel);
        }
    }
}
