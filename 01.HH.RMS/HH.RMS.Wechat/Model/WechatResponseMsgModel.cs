using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Wechat.Model
{
    public class WechatResponseMsgModel
    {
        public string WechatId { get; set; }
        public string Key { get; set; }

        public WechatMsgSearchType SearchType { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }
        public string Type { get; set; }
        public string Url2 { get; set; }
        public string Url { get; set; }

        public int? Probability { get; set; }

        public int Flag { get; set; }

        public int OrderBy { get; set; }

        public DateTime? FromTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string MediaId { get; set; }
    }
}
