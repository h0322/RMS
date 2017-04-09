using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HH.RMS.Wechat;
using HH.RMS.Wechat.Message;
using HH.RMS.Wechat.Model;
using HH.RMS.Service.Wechat;

using HH.RMS.Service.Web;
using HH.RMS.IService.Wechat;
using HH.RMS.IService.Wechat.Model;


namespace HH.RMS.Console.Wechat
{
    public class SendMessage
    {
        public SendMessage()
        {
            string postString = "<xml><ToUserName><![CDATA[gh_f9717ac9e758]]></ToUserName> <FromUserName><![CDATA[o2Xz5s7gsaUAVuk_lte_iOPdDPwk]]></FromUserName> <CreateTime>1467876889</CreateTime> <MsgType><![CDATA[text]]></MsgType> <Content><![CDATA[明星产品]]></Content> <MsgId>6304483233223097116</MsgId> </xml>";
            //MessageManager.instance.Manager(postString);
            IResponseMessageService ms = new SendMessageDefine();
            ms.Manager(postString);

        }

        

    }
    public class SendMessageDefine :ResponseMessageService
    {
        public override void ProcessMsg(BaseProcess processMsg, WechatReceiveModel postModel)
        {
            if (postModel.msgType == "text")
            {
                var aa = new ProcessTextDefine();
                aa.Process(postModel);
            }
            base.ProcessMsg(processMsg, postModel);
        }
    }
    public class ProcessTextDefine : ProcessText
    {
        public override void Process(WechatReceiveModel model)
        {
            base.Process(model);
        }
        public override void ResponseMsg(List<WechatResponseMsgModel> model, string from, string to)
        {
            base.ResponseMsg(model, from, to);
        }
        public override void SendMessage()
        {
            base.SendMessage();
        }
    }

}
