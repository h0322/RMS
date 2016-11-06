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
    public class MessageManager
    {

        public virtual void ProcessMsg(BaseProcess processMsg, WechatPostModel postModel)
        {
            try
            {
                processMsg.Process(postModel);
            }
            catch (Exception ex)
            {
                Config.log.Error("MessageManager.SetProcess", ex);
            }
        }
        public void Manager(string postString)
        {
            try
            {
                WechatPostModel postModel = XMLHelper.Deserialize<WechatPostModel>(postString);
                if (postModel == null)
                {
                    Config.log.Info("MessageManager.Manager:postModel Is NULL"+postString);
                    return;
                }
                switch (postModel.msgType)
                {
                    case "text":
                        ProcessMsg(new ProcessText(), postModel);
                        break;
                    case "image":
                        ProcessMsg(new ProcessImage(), postModel);
                        break;
                    case "location":
                        ProcessMsg(new ProcessLocation(), postModel);
                        break;
                    case "event":
                        ProcessMsg(new ProcessEvent(), postModel);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("MessageManager.Manager", ex);
            }
        }
        public virtual void TextMsg(WechatPostModel postModel)
        {
            
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
