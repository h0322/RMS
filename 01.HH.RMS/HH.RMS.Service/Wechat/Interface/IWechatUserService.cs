using HH.RMS.Service.Wechat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Wechat.Interface
{
    public interface IWechatUserService
    {
        WechatUserModel GetWechatUserByOpenId(string openId, string lang = "zh_CN");
    }
}
