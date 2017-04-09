using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.IService.Wechat;
using HH.RMS.IService.Wechat.Model;
using HH.RMS.Wechat.Message;
using HH.RMS.Wechat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Wechat
{
    public class ResponseMessageService : IResponseMessageService
    {
        public virtual void ProcessMsg(BaseProcess processMsg, WechatReceiveModel postModel)
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
                WechatReceiveModel postModel = XMLHelper.Deserialize<WechatReceiveModel>(postString);
                if (postModel == null)
                {
                    Config.log.Info("MessageManager.Manager:postModel Is NULL" + postString);
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
    }
}
