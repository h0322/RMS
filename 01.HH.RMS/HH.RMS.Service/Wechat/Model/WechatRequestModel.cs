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
        public string url { get; set; }
        public string data { get; set; }
        public string channelCode { get; set; }
        public string signature { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
