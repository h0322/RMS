
using HH.RMS.Common.Model;
using HH.RMS.IService.Wechat.Model;
using HH.RMS.Wechat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService.Wechat
{
    public interface IWechatRequestService
    {
        ResultModel<string> PostData(WechatRequestModel model);
        ResultModel<string> GetData(WechatRequestModel model);
    }
}
