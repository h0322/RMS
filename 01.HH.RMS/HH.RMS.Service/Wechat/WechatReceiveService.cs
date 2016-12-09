using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity.Wechat;
using HH.RMS.Entity.EntityFramework;
using HH.RMS.Entity.EntityFramework.Interface;
using HH.RMS.Service.Wechat.Interface;
using HH.RMS.Service.Wechat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace HH.RMS.Service.Wechat
{
    public class WechatReceiveService : IWechatReceiveService
    {
        private IRepository<WechatReceiveEntity> _receiveRepository { get; set; }
        public WechatReceiveService(IRepository<WechatReceiveEntity> receiveRepository)
        {
            this._receiveRepository = receiveRepository;
        }
        public string ReturnEchostr(string signature, string timestamp, string nonce, string echostr)
        {
            string str = AccessTokenModel.CurrentCache.accessToken + timestamp + nonce;
            string sign = FormsAuthentication.HashPasswordForStoringInConfigFile(str, "SHA1").ToLower();
            if (sign == signature)
            {
                return echostr;
            }
            else
            {
                Config.log.Info("WechatReceiveService.CheckSignature:Signature Error;signature:" + signature + ";sign:" + sign);
                return "";
            }
        }
        public void ReceiveMessage(string postString)
        {
            try
            {
                WechatReceiveModel receiveModel = XMLHelper.Deserialize<WechatReceiveModel>(postString);
                SaveReceiveMessage(receiveModel);
                if (receiveModel == null)
                {
                    Config.log.Info("MessageManager.Manager:postModel Is NULL" + postString);
                    return;
                }

            }
            catch (Exception ex)
            {
                return;
            }
        }
        public ResultType SaveReceiveMessage(WechatReceiveModel receiveModel)
        {
            try
            {
                var entity = WechatReceiveModel.EntityMapper<WechatReceiveEntity>(receiveModel);
                using (var db = new ApplicationDbContext())
                {
                    int result = _receiveRepository.Insert(db, entity);
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
                Config.log.Error("WechatReceiveService.SaveReceiveMessage", ex);
                return ResultType.SystemError;
            }
        }

    }
}
