using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Service.Wechat.Interface;
using HH.RMS.Service.Wechat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace HH.RMS.Service.Wechat
{
    public class WechatReceiveService : IWechatReceiveService
    {
        public WechatReceiveService()
        {
        }
        public string ReturnEchostr(WechatReceiveModel model)
        {
            string signature = FormsAuthentication.HashPasswordForStoringInConfigFile(model.ToString(), "SHA1").ToLower();
            if (signature == model.signature)
            {
                return model.echostr;
            }
            else
            {
                Config.log.Info("WechatReceiveService.CheckSignature:Signature Error;model.signature:" + model.signature + ";signature:" + signature);
                return "";
            }
        }

    }
}
