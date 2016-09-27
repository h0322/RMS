using HH.RMS.Common.Constant;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Wechat.Model
{
    public class WechatRequestModel
    {
        public string appId { get; set; }
        public string appSecret { get; set; }
        public string data { get; set; }
        public string channelCode { get; set; }
        public string signature { get; set; }
        public WechatUrlType wechatUrlType { get; set; }
        public string GetWechatUrl()
        {
            if (Config.wechatUrlDictionary.ContainsKey(this.wechatUrlType))
            {
                return Config.wechatUrlDictionary[this.wechatUrlType];
            }
            return null;
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
