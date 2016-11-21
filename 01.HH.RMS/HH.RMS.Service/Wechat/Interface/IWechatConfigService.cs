using HH.RMS.Entity.Wechat;
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
    }
}
