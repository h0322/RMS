using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Wechat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace HH.RMS.Wechat.Message
{
    public class MessageManager : MessageProcess
    {
        private ProcessAdaptor processAdaptor { get; set; }
        public MessageManager()
        { 
        }
        public override void Process(WechatPostModel model)
        {
            processAdaptor.Process(model);
        }
        public override void ResponseMsg(List<WechatResponseMsgModel> model, string from, string to)
        {
            processAdaptor.ResponseMsg(model, from, to);
        }
        public override void SetProcess(object value)
        {
            processAdaptor = (ProcessAdaptor)value;
        }
        //public static MessageManager instance
        //{
        //    get { return _instance; }
        //}
        //public void Manager(string postString)
        //{
        //    try
        //    {
        //        WechatPostModel postModel = XMLHelper.Deserialize<WechatPostModel>(postString);
        //        MessageProcess messageProcess = null;
        //        switch (postModel.msgType)
        //        {
        //            case "text":
        //                messageProcess = new ProcessText();
        //                break;
        //            case "image":
        //                messageProcess = new ProcessImage();
        //                break;
        //            case "location":
        //                messageProcess = new ProcessLocation();
        //                break;
        //            case "event":
        //                messageProcess = new ProcessEvent();
        //                break;
        //            default:
        //                break;
        //        }
        //        if (messageProcess != null)
        //        {
        //            messageProcess.Process(postModel);
        //        }
        //        else
        //        {
        //            Config.log.Info("MsgType Is NULL:" + postString);
        //        }               
        //    }
        //    catch (Exception ex)
        //    {
        //        Config.log.Error("MessageManager.Manager", ex);
        //    }
        //}
    }
}
