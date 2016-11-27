using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Wechat
{
    public class WechatUserEntity:EntityBase
    {
        public long accountId { get; set; }
        public WechatSubscribeType subscribe { get; set; }
        [MaxLength(20)]
        public string openId { get; set; }
        [MaxLength(100)]
        public string nickname { get; set; }
        public SexType sex { get; set; }
        [MaxLength(50)]
        public string language { get; set; }
        [MaxLength(50)]
        public string city { get; set; }
        [MaxLength(50)]
        public string province { get; set; }
        [MaxLength(50)]
        public string country { get; set; }
        [MaxLength(500)]
        public string headimgurl { get; set; }
        [MaxLength(50)]
        public string subscribeTime { get; set; }
        [MaxLength(50)]
        public string unionid { get; set; }
        [MaxLength(500)]
        public string remark { get; set; }
        public int groupId { get; set; }
    }
}
