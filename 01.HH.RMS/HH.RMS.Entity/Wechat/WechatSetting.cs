using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Wechat
{
    public class WechatSetting:EntityBase
    {
        [MaxLength(20)]
        public string name { get; set; }
        [MaxLength(100)]
        public string description { get; set; }
        [MaxLength(20)]
        public string openId { get; set; }
        [MaxLength(20)]
        public string appId { get; set; }
        [MaxLength(20)]
        public string appName { get; set; }
        [MaxLength(50)]
        public string appSecret { get; set; }
        [MaxLength(50)]
        public string accessToken { get; set; }
        [MaxLength(20)]
        public string key { get; set; }
        [MaxLength(50)]
        public string security { get; set; }
        [MaxLength(100)]
        public string url { get; set; }
        [MaxLength(100)]
        public string imageUrl { get; set; }
    }
}
