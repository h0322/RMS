using HH.RMS.IService.Wechat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService.Wechat
{
    public interface IWechatReceiveService
    {
        string ReturnEchostr(string signature, string timestamp, string nonce, string echostr);
    }
}
