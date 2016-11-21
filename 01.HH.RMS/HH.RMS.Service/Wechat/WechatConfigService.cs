using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity.Wechat;
using HH.RMS.Repository.EntityFramework;
using HH.RMS.Repository.EntityFramework.Interface;
using HH.RMS.Service.Model;
using HH.RMS.Service.Wechat.Interface;
using HH.RMS.Service.Wechat.Model;
using HH.RMS.Wechat.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Wechat
{
    public class WechatConfigService:IWechatConfigService
    {
        private IRepository<WechatConfigEntity> _wechatConfigRepository;
        public WechatConfigService(IRepository<WechatConfigEntity> wechatConfigRepository)
        {
            this._wechatConfigRepository = wechatConfigRepository;
        }
        public WechatConfigModel QueryWechatConfig()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var entity = _wechatConfigRepository.Query(db).FirstOrDefault();
                    return WechatConfigModel.ModelMapper<WechatConfigModel>(entity);
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("WechatConfigService.QueryWechatConfig", ex);
                return null;
            }
        }
        public ResultType UpdateWechatConfig(WechatConfigModel model)
        {
            try
            {
                var entity = WechatConfigModel.EntityMapper<WechatConfigEntity>(model);
                if (entity == null)
                {
                    return ResultType.NotExists;
                }
                using (var db = new ApplicationDbContext())
                {
                    int result = _wechatConfigRepository.Update(db, entity);
                    if (result > 0)
                    {
                        return ResultType.Success;
                    }
                    else
                    {
                        return ResultType.Fail;
                    }
                }
                
            }
            catch (Exception ex)
            {
                Config.log.Error("WechatConfigService.UpdateWechatConfig", ex);
                return ResultType.SystemError;
            }
        }

        public ResultModel<AccessTokenModel> GetAccessToken(WechatRequestModel model)
        {
            try
            {
                string url = model.GetWechatUrl();
                if (url == null)
                {
                    return new ResultModel<AccessTokenModel>(ResultType.NotExists, "该功能不存在");
                }
                string wechatUrl = string.Format(url, model.appId, model.appSecret);
                string result = NetHelper.Get(wechatUrl);
                if (string.IsNullOrEmpty(result))
                {
                    return new ResultModel<AccessTokenModel>(ResultType.Fail, "微信访问失败");
                }
                AccessTokenModel accessToken = JsonConvert.DeserializeObject<AccessTokenModel>(result);

                return new ResultModel<AccessTokenModel>(ResultType.Success, accessToken);
            }
            catch (Exception ex)
            {
                Config.log.Error("AccessTokenService.GetAccessToken", ex);
                return null;
            }
            //model.GetWechatUrl
        }
    }
}
