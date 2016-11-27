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
        WechatUserResponseModel GetWechatUserByOpenId(WechatUserRequestModel requestModel);
        List<WechatUserResponseModel> BatchGetWechatUserByOpenId(List<WechatUserRequestModel> requestModel);
        WechatOpenIdListResponseModel GetWechatOpenIdList(string nextOpenId = "");
    }
}
