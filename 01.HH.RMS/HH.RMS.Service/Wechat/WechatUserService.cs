using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Service.Wechat.Interface;
using HH.RMS.Service.Wechat.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Wechat
{
    public class WechatUserService : IWechatUserService
    {
        public WechatUserResponseModel GetWechatUserByOpenId(WechatUserRequestModel requestModel)
        {
            string wechatUrl = string.Format(Config.getDetailUserInfoUrl, AccessTokenModel.CurrentCache.accessToken, requestModel.openId, requestModel.lang);
            try
            {
                string result = NetHelper.Get(wechatUrl);
                Config.log.Info("WechatUserService.GetWechatUserByOpenId:Result;Message:" + result);
                WechatUserResponseModel model = JsonConvert.DeserializeObject<WechatUserResponseModel>(result);
                return model;
            }
            catch (Exception ex)
            {
                Config.log.Error("WechatUserService.GetWechatUserByOpenId", ex);
                return null;
            }

        }
        public List<WechatUserResponseModel> BatchGetWechatUserByOpenId(List<WechatUserRequestModel> requestModel)
        {
            string wechatUrl = string.Format(Config.getDetailUserInfoListUrl, AccessTokenModel.CurrentCache.accessToken);
            try
            {
                string postData = "{\"user_list\":" + JsonConvert.SerializeObject(requestModel) + "}";
                string result = NetHelper.Post(wechatUrl, postData);
                Config.log.Info("WechatUserService.BatchGetWechatUserByOpenId:Result;Message:" + result);
                List<WechatUserResponseModel> list = JsonConvert.DeserializeObject<List<WechatUserResponseModel>>(result);
                return list;
            }
            catch (Exception ex)
            {
                Config.log.Error("WechatUserService.BatchGetWechatUserByOpenId", ex);
                return null;
            }
        }
        public WechatOpenIdListResponseModel GetWechatOpenIdList(string nextOpenId="")
        {
            string wechatUrl = string.Format(Config.getUserInfoListUrl, AccessTokenModel.CurrentCache.accessToken, nextOpenId);
            try
            {
                string result = NetHelper.Get(wechatUrl);
                Config.log.Info("WechatUserService.BatchGetWechatUserByOpenId:Result;Message:" + result);
                WechatOpenIdListResponseModel model = JsonConvert.DeserializeObject<WechatOpenIdListResponseModel>(result);
                return model;
            }
            catch (Exception ex)
            {
                Config.log.Error("WechatUserService.GetWechatOpenIdList", ex);
                return null;
            }
        }
    }
}
