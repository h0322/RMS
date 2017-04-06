using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.IService.Wechat;
using HH.RMS.IService.Wechat.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Wechat
{
    public class WechatQRCodeService : IWechatQRCodeService
    {
        public string GetQRCodeTicket()
        {
            string wechatUrl = string.Format(Config.createQRCodeTicketUrl, AccessTokenModel.CurrentCache.accessToken);
            try
            {
                return NetHelper.Get(wechatUrl);
            }
            catch (Exception ex)
            {
                Config.log.Error("WechatQRCodeService.GetQRCodeTicket", ex);
                return null;
            }
        }
        public string GetQRCodeUrl()
        {
            string getQRCodeTicket = GetQRCodeTicket();
            if (getQRCodeTicket == null)
            {
                return null;
            }
            JObject jsonObj = JsonConvert.DeserializeObject<JObject>(getQRCodeTicket);
            string ticket = "";
            if (jsonObj["ticket"] == null)
            {
                return null;
            }
            ticket = jsonObj["ticket"].ToString();
            string wechatUrl = string.Format(Config.showQRCodeUrl, ticket);
            return wechatUrl;
        }
        public ResultType SaveQRCode(string filePath)
        {
            string qrCodeUrl = GetQRCodeUrl();
            if(qrCodeUrl==null)
            {
                return ResultType.Fail;
            }
            try
            {
                NetHelper.DownLoadFile(qrCodeUrl, filePath);
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                Config.log.Error("WechatQRCodeService.SaveQRCode", ex);
                return ResultType.SystemError;
            }
        }
    }
}
