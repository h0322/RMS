using HH.RMS.Common.Utilities;
using log4net;
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
        #region log
        public static readonly log4net.ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region ConnectionString
        public static string sqlConnStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        public static string sqlLogConnStr = ConfigurationManager.ConnectionStrings["LogConnection"].ToString();
        #endregion

        #region AppSetting

        public static readonly string serverName = ConfigHelper.GetConfigString("ServerName");
        public static readonly string siteName = ConfigHelper.GetConfigString("SiteName");
        public static readonly string webProxyUrl = ConfigHelper.GetConfigString("WebProxyURL");
        public static readonly string webProxyPort = ConfigHelper.GetConfigString("WebProxyPort");
        public static readonly string webProxyUserName = ConfigHelper.GetConfigString("WebProxyUserName");
        public static readonly string webProxyPassword = ConfigHelper.GetConfigString("WebProxyPassword");
        public static readonly int isWebProxy = ConfigHelper.GetConfigInt("IsWebProxy");
        public static readonly string webProxyDomain = ConfigHelper.GetConfigString("WebProxyDomain");
        public static readonly string wechatAppId = ConfigHelper.GetConfigString("WechatAppId");
        public static readonly string wechatAppSecret = ConfigHelper.GetConfigString("WechatAppSecret");
        #endregion

        #region Constant
        public readonly static string wechatOpenIdSession = "WechatOpenIdSession";
        public readonly static string loginSession = "AccountDetailsSession";
        public readonly static string menuSession = "SystemMenusSession";
        public readonly static string menuRoleSession = "MenuRoleSession";
        public readonly static string provinceCache = "ProvinceCache";
        public readonly static string cityCache = "CityCache";
        public readonly static string countryCache = "CountryCache";
        public readonly static string levelCache = "LevelCache";
        public readonly static string menuCache = "MenuCache";
        public readonly static string roleCache = "RoleCache";
        public readonly static string accessTokenCache = "AccessTokenCache";
        public const string wechatSDKTikcet = "WechatSDKTikcet";
        #endregion

        #region Wechat
        public static readonly string createMenuUrl= "https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}";
        public static readonly string getJsapiTicketUrl= "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi";
        public static readonly string getCardapiTicketUrl= "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=wx_card";
        public static readonly string getMenuDataUrl= "https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}";
        public static readonly string deleteMenuUrl= "https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}";
        public static readonly string addConditionalMenuUrl= "https://api.weixin.qq.com/cgi-bin/menu/addconditional?access_token={0}";
        public static readonly string deleteConditionalMenuUrl= "https://api.weixin.qq.com/cgi-bin/menu/delconditional?access_token={0}";
        public static readonly string getCurrentSelfMenuUrl= "https://api.weixin.qq.com/cgi-bin/get_current_selfmenu_info?access_token={0}";
        public static readonly string createGroupUrl= "https://api.weixin.qq.com/cgi-bin/groups/create?access_token={0}";
        public static readonly string getAllGroupsUrl= "https://api.weixin.qq.com/cgi-bin/groups/get?access_token={0}";
        public static readonly string getMemberGroupUrl= "https://api.weixin.qq.com/cgi-bin/groups/getid?access_token={0}";
        public static readonly string updateGroupUrl= "https://api.weixin.qq.com/cgi-bin/groups/update?access_token={0}";
        public static readonly string moveMemberGroupUrl= "https://api.weixin.qq.com/cgi-bin/groups/members/update?access_token={0}";
        public static readonly string batchMoveMemberGroupUrl= "https://api.weixin.qq.com/cgi-bin/groups/members/batchupdate?access_token={0}";
        public static readonly string deleteGroupUrl= "https://api.weixin.qq.com/cgi-bin/groups/delete?access_token={0}";
        public static readonly string createQRCodeTicketUrl= "https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={0}";
        public static readonly string showQRCodeUrl= "https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket={0}";
        public static readonly string getShortUrlUrl= "https://api.weixin.qq.com/cgi-bin/shorturl?access_token={0}";
        public static readonly string getDetailUserInfoListUrl= "https://api.weixin.qq.com/cgi-bin/user/info/batchget?access_token={0}";
        public static readonly string updateRemarkUrl= "https://api.weixin.qq.com/cgi-bin/user/info/updateremark?access_token={0}";
        public static readonly string sendTemplateUrl= "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}";
        public static readonly string createCardsUrl= "https://api.weixin.qq.com/card/create?access_token={0}";
        public static readonly string getCardStatusUrl= "https://api.weixin.qq.com/card/get?access_token={0}";
        public static readonly string grantCardUrl= "https://api.weixin.qq.com/card/mpnews/gethtml?access_token={0}";
        public static readonly string ActivateCardUrl= "https://api.weixin.qq.com/card/membercard/activate?access_token={0}";
        public static readonly string updateCardUrl= "https://api.weixin.qq.com/card/update?access_token={0}";
        public static readonly string modifystockUrl= "https://api.weixin.qq.com/card/modifystock?access_token={0}";
        public static readonly string deleteCardUrl= "https://api.weixin.qq.com/card/delete?access_token={0}";
        public static readonly string customSendUrl= "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}";
        public static readonly string opendialogueUrl=" https://api.weixin.qq.com/customservice/kfsession/create?access_token={0}&lang=zh_CN";
        public static readonly string closedialogueUrl= "https://api.weixin.qq.com/customservice/kfsession/close?access_token={0}&lang=zh_CN";
        public static readonly string getMsgRecordUrl= "https://api.weixin.qq.com/customservice/msgrecord/getrecord?access_token={0}";
        public static readonly string getKFListUrl= "https://api.weixin.qq.com/cgi-bin/customservice/getkflist?access_token={0}";
        public static readonly string getOnLineKFListUrl= "https://api.weixin.qq.com/cgi-bin/customservice/getonlinekflist?access_token={0}";
        public static readonly string createCustomUrl= "https://api.weixin.qq.com/customservice/kfaccount/add?access_token={0}";
        public static readonly string updateCustomUrl= "https://api.weixin.qq.com/customservice/kfaccount/update?access_token={0}";
        public static readonly string deleteCustomUrl= "https://api.weixin.qq.com/customservice/kfaccount/del?access_token={0}&kf_account={1}";
        public static readonly string sendMsgMassByUserGroupUrl= "https://api.weixin.qq.com/cgi-bin/message/mass/sendall?access_token={0}";
        public static readonly string sendMsgMassByOpenidUrl= "https://api.weixin.qq.com/cgi-bin/message/mass/send?access_token={0}";
        public static readonly string deleteGroupMsgUrl= "https://api.weixin.qq.com/cgi-bin/message/mass/delete?access_token={0}";
        public static readonly string getUserSummaryUrl= "https://api.weixin.qq.com/datacube/getusersummary?access_token={0}";
        public static readonly string getUserCumulateUrl= "https://api.weixin.qq.com/datacube/getusercumulate?access_token={0}";
        public static readonly string getArticleSummaryUrl= "https://api.weixin.qq.com/datacube/getarticlesummary?access_token={0}";
        public static readonly string getArticleTotalUrl= "https://api.weixin.qq.com/datacube/getarticletotal?access_token={0}";
        public static readonly string getUserReadUrl= "https://api.weixin.qq.com/datacube/getuserread?access_token={0}";
        public static readonly string getUserReadHourUrl= "https://api.weixin.qq.com/datacube/getuserreadhour?access_token={0}";
        public static readonly string getUserShareUrl= "https://api.weixin.qq.com/datacube/getusershare?access_token={0}";
        public static readonly string getUserShareHourUrl= "https://api.weixin.qq.com/datacube/getusersharehour?access_token={0}";
        public static readonly string getUpStreamMsgUrl= "https://api.weixin.qq.com/datacube/getupstreammsg?access_token={0}";
        public static readonly string getUpStreamMsgByHourUrl= "https://api.weixin.qq.com/datacube/getupstreammsghour?access_token={0}";
        public static readonly string getUpStreamMsgByWeekUrl= "https://api.weixin.qq.com/datacube/getupstreammsgweek?access_token={0}";
        public static readonly string getUpStreamMsgByMonthUrl= "https://api.weixin.qq.com/datacube/getupstreammsgmonth?access_token={0}";
        public static readonly string getUpStreamMsgDistUrl= "https://api.weixin.qq.com/datacube/getupstreammsgdist?access_token={0}";
        public static readonly string getUpStreamMsgDistByWeekUrl= "https://api.weixin.qq.com/datacube/getupstreammsgdistweek?access_token={0}";
        public static readonly string getUpStreamMsgDistByMonthUrl= "https://api.weixin.qq.com/datacube/getupstreammsgdistmonth?access_token={0}";
        public static readonly string getInterfaceSummaryUrl= "https://api.weixin.qq.com/datacube/getinterfacesummary?access_token={0}";
        public static readonly string getInterfaceSummaryByHourUrl= "https://api.weixin.qq.com/datacube/getinterfacesummaryhour?access_token={0}";
        public static readonly string getCardQrCodeUrl= "https://api.weixin.qq.com/card/qrcode/create?access_token={0}";
        public static readonly string createMaterialUrl= "https://api.weixin.qq.com/cgi-bin/material/add_news?access_token={0}";
        public static readonly string getMaterialUrl= "https://api.weixin.qq.com/cgi-bin/material/get_material?access_token={0}";
        public static readonly string deleteMaterialUrl= "https://api.weixin.qq.com/cgi-bin/material/del_material?access_token={0}";
        public static readonly string updateMaterialUrl= "https://api.weixin.qq.com/cgi-bin/material/update_news?access_token={0}";
        public static readonly string getMaterialCountUrl= "https://api.weixin.qq.com/cgi-bin/material/get_materialcount?access_token={0}";
        public static readonly string getMaterialListUrl= "https://api.weixin.qq.com/cgi-bin/material/batchget_material?access_token={0}";
        public static readonly string uploadImgUrl= "https://api.weixin.qq.com/cgi-bin/media/uploadimg?access_token={0}";
        public static readonly string registerUrl= "https://api.weixin.qq.com/shakearound/account/register?access_token={0}";
        public static readonly string auditStatusUrl= "https://api.weixin.qq.com/shakearound/account/auditstatus?access_token={0}";
        public static readonly string createPoiUrl= "http://api.weixin.qq.com/cgi-bin/poi/addpoi?access_token={0}";
        public static readonly string getPoiUrl= "http://api.weixin.qq.com/cgi-bin/poi/getpoi?access_token={0}";
        public static readonly string getPoiListUrl= "https://api.weixin.qq.com/cgi-bin/poi/getpoilist?access_token={0}";
        public static readonly string updatePoiUrl= "https://api.weixin.qq.com/cgi-bin/poi/updatepoi?access_token={0}";
        public static readonly string deletePoiUrl= "https://api.weixin.qq.com/cgi-bin/poi/delpoi?access_token={0}";
        public static readonly string getWxCategoryUrl= "http://api.weixin.qq.com/cgi-bin/poi/getwxcategory?access_token={0}";
        public static readonly string getUserinfoUrl= "https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN";
        public static readonly string getAuthorizeUrl= "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope={2}&state={3}#wechat_redirect";
        public static readonly string getAccessTokenByCodeUrl= "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";
        public static readonly string getsessionUrl= "https://api.weixin.qq.com/customservice/kfsession/getsession?access_token={0}&openid={1}&lang=zh_CN";
        public static readonly string getUserInfoListUrl= "https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&next_openid={1}";
        public static readonly string getOpenidTokenUrl= "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type={3}";
        public static readonly string getDetailUserInfoUrl= "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang={2}";
        public static readonly string getRefershAccessTokenUrl= "https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}";
        public static readonly string getMediaUrl= "http://file.Api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}";
        public static readonly string getPreviewUrl= "https://api.weixin.qq.com/cgi-bin/message/mass/preview?access_token={0}";
        public static readonly string invitationCustomUrl= "https://api.weixin.qq.com/customservice/kfaccount/inviteworker?access_token={0}";//邀请绑定客服
        public static readonly string getAccessToken= "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";//邀请绑定客服
        public static readonly int accessTokenRemainSecond = 1000;
        #endregion

        #region Job
        public const string jobAssemblyFullName = "jobAssemblyFullName";
        public const string jobAssembly = "jobAssembly";
        public const string jobAssemblyPath = "jobAssemblyPath";
        public const string jobAssemblyMethod = "jobAssemblyMethod";
        public const string jobCommandText = "jobCommandText";
        public const string jobCommandType = "jobCommandType";
        public const string jobUrl = "jobUrl";
        public const string jobId = "jobId";
        public const string schedulerId = "schedulerId";
        #endregion



    }
}
