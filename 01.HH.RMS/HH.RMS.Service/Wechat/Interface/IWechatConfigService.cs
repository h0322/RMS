using HH.RMS.Common.Constant;
using HH.RMS.Entity.Wechat;
using HH.RMS.Service.Model;
using HH.RMS.Service.Wechat.Model;
using HH.RMS.Wechat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Wechat.Interface
{
    public interface IWechatConfigService
    {
        WechatConfigModel QueryWechatConfig();
        ResultModel<AccessTokenModel> GetAccessToken();
    }
}
