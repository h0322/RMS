using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService.Wechat.Model
{
    public class WechatMsgTemplateModel
    {
        public string touser { get; set; }
        public string templateId { get; set; }
        public string url { get; set; }
        public WechatMsgTemplagteDataModel data { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class WechatMsgTemplagteDataModel
    {
        public WechatMsgTemplagteContentModel first { get; set; }
        public WechatMsgTemplagteContentModel key1 { get; set; }
        public WechatMsgTemplagteContentModel key2 { get; set; }
        public WechatMsgTemplagteContentModel key3 { get; set; }
        public WechatMsgTemplagteContentModel key4 { get; set; }
        public WechatMsgTemplagteContentModel key5 { get; set; }
        public WechatMsgTemplagteContentModel key6 { get; set; }
        public WechatMsgTemplagteContentModel key7 { get; set; }
        public WechatMsgTemplagteContentModel key8 { get; set; }
        public WechatMsgTemplagteContentModel remark { get; set; }
    }
    public class WechatMsgTemplagteContentModel
    {
        public string value { get; set; }
        public string color { get; set; }
    }

}
