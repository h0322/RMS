using HH.RMS.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Wechat
{
    [MappingTable(tableName = "WechatConfig")]
    public class WechatConfigEntity:EntityBase
    {
        [MaxLength(100)]
        public string name { get; set; }
        [MaxLength(500)]
        public string description { get; set; }
        [MaxLength(20)]
        public string openId { get; set; }
        [MaxLength(100)]
        public string appId { get; set; }
        [MaxLength(100)]
        public string appName { get; set; }
        [MaxLength(100)]
        public string appSecret { get; set; }
        [MaxLength(500)]
        public string accessToken { get; set; }
        [MaxLength(100)]
        public string token { get; set; }
        [MaxLength(100)]
        public string security { get; set; }
        [MaxLength(100)]
        public string ticket { get; set; }
        [MaxLength(100)]
        public string componentName { get; set; }
        [MaxLength(100)]
        public string componentAppId { get; set; }
        [MaxLength(100)]
        public string componentAppSecret { get; set; }
        [MaxLength(500)]
        public string componentAccessToken { get; set; }
        [MaxLength(500)]
        public string url { get; set; }
        [MaxLength(500)]
        public string imageUrl { get; set; }
    }
}
