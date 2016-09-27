using HH.RMS.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Common.Constant
{
    public class Config
    {
        public static string sqlConnStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        public static string sqlLogConnStr = ConfigurationManager.ConnectionStrings["LogConnection"].ToString();
        public static readonly string emailSender = ConfigHelper.GetConfigString("EmailSender");
        public static readonly string emailSenderPwd = ConfigHelper.GetConfigString("EmailSenderPwd");
        public static readonly string smtpServer = ConfigHelper.GetConfigString("SmtpServer");
        public static readonly string serverName = ConfigHelper.GetConfigString("ServerName");
        public static readonly string siteName = ConfigHelper.GetConfigString("SiteName");
        public static readonly string webProxyUrl = ConfigHelper.GetConfigString("WebProxyURL");
        public static readonly string webProxyPort = ConfigHelper.GetConfigString("WebProxyPort");
        public static readonly string webProxyUserName = ConfigHelper.GetConfigString("WebProxyUserName");
        public static readonly string webProxyPassword = ConfigHelper.GetConfigString("WebProxyPassword");
        public static readonly string isWebProxy = ConfigHelper.GetConfigString("IsWebProxy");
        public static readonly string webProxyDomain = ConfigHelper.GetConfigString("WebProxyDomain");
        public static readonly string wechatAppId = ConfigHelper.GetConfigString("WechatAppId");
        public static readonly string wechatAppSecret = ConfigHelper.GetConfigString("WechatAppSecret");
        public readonly static string loginSession = "AccountDetailsSession";
        public readonly static string menuSession = "SystemMenusSession";
        public readonly static string provinceCache = "ProvinceCache";
        public readonly static string cityCache = "CityCache";
        public readonly static string countryCache = "CountryCache";
        public readonly static string levelCache = "LevelCache";
        public readonly static string roleCache = "RoleCache";
        public readonly static string accessTokenCache = "AccessTokenCache";
        #region WechatUrl
        private static Dictionary<WechatUrlType, string> _wechatUrlDictionary = null;
        public static Dictionary<WechatUrlType, string> wechatUrlDictionary
        {
            get {
                if (_wechatUrlDictionary == null)
                {
                    _wechatUrlDictionary = new Dictionary<WechatUrlType, string>();
                    _wechatUrlDictionary.Add(WechatUrlType.CreateMenuUrl, "https://api.weixin.qq.com/cgi-bin/menu/Create?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetJsapiTicketUrl, "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi");
                    _wechatUrlDictionary.Add(WechatUrlType.GetCardapiTicketUrl, "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=wx_card");
                    _wechatUrlDictionary.Add(WechatUrlType.GetMenuDataUrl, "https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.DeleteMenuUrl, "https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.AddConditionalMenuUrl, "https://api.weixin.qq.com/cgi-bin/menu/addconditional?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.DeleteConditionalMenuUrl, "https://api.weixin.qq.com/cgi-bin/menu/delconditional?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetCurrentSelfMenuUrl, "https://api.weixin.qq.com/cgi-bin/get_current_selfmenu_info?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.CreateGroupUrl, "https://api.weixin.qq.com/cgi-bin/groups/Create?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetAllGroupsUrl, "https://api.weixin.qq.com/cgi-bin/groups/get?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetMemberGroupUrl, "https://api.weixin.qq.com/cgi-bin/groups/getid?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.UpdateGroupUrl, "https://api.weixin.qq.com/cgi-bin/groups/update?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.MoveMemberGroupUrl, "https://api.weixin.qq.com/cgi-bin/groups/members/update?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.BatchMoveMemberGroupUrl, "https://api.weixin.qq.com/cgi-bin/groups/members/batchupdate?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.DeleteGroupUrl, "https://api.weixin.qq.com/cgi-bin/groups/delete?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.CreateQRCodeTicketUrl, "https://api.weixin.qq.com/cgi-bin/qrcode/Create?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.ShowQRCodeUrl, "https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetShortUrlUrl, "https://api.weixin.qq.com/cgi-bin/shorturl?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetDetailUserInfoListUrl, "https://api.weixin.qq.com/cgi-bin/user/info/batchget?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.UpdateRemarkUrl, "https://api.weixin.qq.com/cgi-bin/user/info/updateremark?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.SendTemplateUrl, "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.CreateCardsUrl, "https://api.weixin.qq.com/card/Create?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetCardStatusUrl, "https://api.weixin.qq.com/card/get?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GrantCardUrl, "https://api.weixin.qq.com/card/mpnews/gethtml?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.ActivateCardUrl, "https://api.weixin.qq.com/card/membercard/activate?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.UpdateCardUrl, "https://api.weixin.qq.com/card/update?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.ModifystockUrl, "https://api.weixin.qq.com/card/modifystock?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.DeleteCardUrl, "https://api.weixin.qq.com/card/delete?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.CustomSendUrl, "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.OpendialogueUrl," https://api.weixin.qq.com/customservice/kfsession/Create?access_token={0}&lang=zh_CN");
                    _wechatUrlDictionary.Add(WechatUrlType.ClosedialogueUrl, "https://api.weixin.qq.com/customservice/kfsession/close?access_token={0}&lang=zh_CN");
                    _wechatUrlDictionary.Add(WechatUrlType.GetMsgRecordUrl, "https://api.weixin.qq.com/customservice/msgrecord/getrecord?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetKFListUrl, "https://api.weixin.qq.com/cgi-bin/customservice/getkflist?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetOnLineKFListUrl, "https://api.weixin.qq.com/cgi-bin/customservice/getonlinekflist?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.CreateCustomUrl, "https://api.weixin.qq.com/customservice/kfaccount/add?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.UpdateCustomUrl, "https://api.weixin.qq.com/customservice/kfaccount/update?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.DeleteCustomUrl, "https://api.weixin.qq.com/customservice/kfaccount/del?access_token={0}&kf_account={1}");
                    _wechatUrlDictionary.Add(WechatUrlType.SendMsgByUserGroupUrl, "https://api.weixin.qq.com/cgi-bin/message/mass/sendall?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.SendMsgByOpenidUrl, "https://api.weixin.qq.com/cgi-bin/message/mass/send?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.DeleteGroupMsgUrl, "https://api.weixin.qq.com/cgi-bin/message/mass/delete?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetUserSummaryUrl, "https://api.weixin.qq.com/datacube/getusersummary?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetUserCumulateUrl, "https://api.weixin.qq.com/datacube/getusercumulate?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetArticleSummaryUrl, "https://api.weixin.qq.com/datacube/getarticlesummary?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetArticleTotalUrl, "https://api.weixin.qq.com/datacube/getarticletotal?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetUserReadUrl, "https://api.weixin.qq.com/datacube/getuserread?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetUserReadHourUrl, "https://api.weixin.qq.com/datacube/getuserreadhour?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetUserShareUrl, "https://api.weixin.qq.com/datacube/getusershare?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetUserShareHourUrl, "https://api.weixin.qq.com/datacube/getusersharehour?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetUpStreamMsgUrl, "https://api.weixin.qq.com/datacube/getupstreammsg?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetUpStreamMsgByHourUrl, "https://api.weixin.qq.com/datacube/getupstreammsghour?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetUpStreamMsgByWeekUrl, "https://api.weixin.qq.com/datacube/getupstreammsgweek?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetUpStreamMsgByMonthUrl, "https://api.weixin.qq.com/datacube/getupstreammsgmonth?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetUpStreamMsgDistUrl, "https://api.weixin.qq.com/datacube/getupstreammsgdist?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetUpStreamMsgDistByWeekUrl, "https://api.weixin.qq.com/datacube/getupstreammsgdistweek?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetUpStreamMsgDistByMonthUrl, "https://api.weixin.qq.com/datacube/getupstreammsgdistmonth?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetInterfaceSummaryUrl, "https://api.weixin.qq.com/datacube/getinterfacesummary?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetInterfaceSummaryByHourUrl, "https://api.weixin.qq.com/datacube/getinterfacesummaryhour?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetCardQrCodeUrl, "https://api.weixin.qq.com/card/qrcode/Create?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.CreateMaterialUrl, "https://api.weixin.qq.com/cgi-bin/material/add_news?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetMaterialUrl, "https://api.weixin.qq.com/cgi-bin/material/get_material?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.DeleteMaterialUrl, "https://api.weixin.qq.com/cgi-bin/material/del_material?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.UpdateMaterialUrl, "https://api.weixin.qq.com/cgi-bin/material/update_news?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetMaterialCountUrl, "https://api.weixin.qq.com/cgi-bin/material/get_materialcount?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetMaterialListUrl, "https://api.weixin.qq.com/cgi-bin/material/batchget_material?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.UploadImgUrl, "https://api.weixin.qq.com/cgi-bin/media/uploadimg?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.RegisterUrl, "https://api.weixin.qq.com/shakearound/account/register?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.AuditStatusUrl, "https://api.weixin.qq.com/shakearound/account/auditstatus?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.CreatePoiUrl, "http://api.weixin.qq.com/cgi-bin/poi/addpoi?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetPoiUrl, "http://api.weixin.qq.com/cgi-bin/poi/getpoi?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetPoiListUrl, "https://api.weixin.qq.com/cgi-bin/poi/getpoilist?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.UpdatePoiUrl, "https://api.weixin.qq.com/cgi-bin/poi/updatepoi?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.DeletePoiUrl, "https://api.weixin.qq.com/cgi-bin/poi/delpoi?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetWxCategoryUrl, "http://api.weixin.qq.com/cgi-bin/poi/getwxcategory?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetUserinfoUrl, "https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN");
                    _wechatUrlDictionary.Add(WechatUrlType.GetAuthorizeUrl, "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope={2}&state={3}#wechat_redirect");
                    _wechatUrlDictionary.Add(WechatUrlType.GetAccessTokenByCodeUrl, "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code");
                    _wechatUrlDictionary.Add(WechatUrlType.GetsessionUrl, "https://api.weixin.qq.com/customservice/kfsession/getsession?access_token={0}&openid={1}&lang=zh_CN");
                    _wechatUrlDictionary.Add(WechatUrlType.GetUserInfoListUrl, "https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&next_openid={1}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetOpenidTokenUrl, "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type={3}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetDetailUserInfoUrl, "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang={2}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetRefershAccessTokenUrl, "https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetMediaUrl, "http://file.Api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}");
                    _wechatUrlDictionary.Add(WechatUrlType.GetPreviewUrl, "https://api.weixin.qq.com/cgi-bin/message/mass/preview?access_token={0}");
                    _wechatUrlDictionary.Add(WechatUrlType.InvitationCustomUrl, "https://api.weixin.qq.com/customservice/kfaccount/inviteworker?access_token={0}");//邀请绑定客服
                    _wechatUrlDictionary.Add(WechatUrlType.GetAccessToken, "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}");//邀请绑定客服
                }
                return _wechatUrlDictionary;
 
            }
        }
  
        #endregion

    }
}
