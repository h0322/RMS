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
    public interface IWechatRequestService
    {
        ResultModel<string> PostData(WechatRequestModel model);
        ResultModel<string> GetData(WechatRequestModel model);
    }
}
