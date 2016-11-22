using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Common.Constant
{
    public enum StatusType
    {
        Nomal=1
    }
    public enum SexType
    {
        Man=1,
        Female=2
    }
    public enum ResultType
    {
        Success = 0,
        Fail=1,
        FieldRequire = 2,
        LengthLess = 3,
        LengthOutSize = 4,
        NotExists = 5,
        IsExists=6,
        NotEqual = 7,
        LessThan=8,
        MoreThan=9,
        NotExecute=10,
        Executing = 10,
        Executed = 11,
        NoAccess=12,
        SystemError = 500,
    }
    public enum IntervalType
    {
        CronExpression = 1,
        OnlyOnce = 2,
        Daily = 3,
        Weekly = 4,
        Monthly = 5,
        Yearly = 6,
    }
    public enum SqlScriptType
    {
        None=0,
        SqlString=1,
        Procedure=2
    }
    public enum AccountStatusType
    {
        Normal =1,
        Disable =2,
        Black=3
    }
    public enum AccountType
    {
        [DescriptionAttribute("系统管理员")]
        Admin=1,
        [DescriptionAttribute("超级用户")]
        SuperUser=2,
        [DescriptionAttribute("普通用户")]
        NormalUser=3
    }
    public enum ObjectType
    { 
        Object=1,
        List=2
     }
    public enum MenuType
    {
        Page=1,
        Menu=2
    }
    public enum DataType
    {
        String=1,
        Int32=2,
        Int64=3,
        DateTime =4,
        Decimal=5,
        Double = 6,
        Boolean = 7
    }
    public enum WechatUrlType
    {
        CreateMenuUrl = 0,
        GetAccessToken = 1,
        GetJsapiTicketUrl=2,
        GetCardapiTicketUrl=3,
        GetMenuDataUrl=4,
        DeleteMenuUrl=5,
        AddConditionalMenuUrl=6,
        DeleteConditionalMenuUrl=7,
        GetCurrentSelfMenuUrl=8,
        CreateGroupUrl=9,
        GetAllGroupsUrl=10,
        GetMemberGroupUrl=11,
        UpdateGroupUrl=12,
        MoveMemberGroupUrl=13,
        BatchMoveMemberGroupUrl=14,
        DeleteGroupUrl=15,
        CreateQRCodeTicketUrl=16,
        ShowQRCodeUrl=17,
        GetShortUrlUrl=18,
        GetDetailUserInfoListUrl=19,
        UpdateRemarkUrl=20,
        SendTemplateUrl=21,
        CreateCardsUrl=22,
        GetCardStatusUrl=23,
        GrantCardUrl=24,
        ActivateCardUrl=25,
        UpdateCardUrl=26,
        ModifystockUrl=27,
        DeleteCardUrl=28,
        CustomSendUrl=29,
        OpendialogueUrl=30,
        ClosedialogueUrl=31,
        GetMsgRecordUrl=32,
        GetKFListUrl=33,
        GetOnLineKFListUrl=34,
        CreateCustomUrl=35,
        UpdateCustomUrl=36,
        DeleteCustomUrl=37,
        SendMsgByUserGroupUrl=38,
        SendMsgByOpenidUrl=39,
        DeleteGroupMsgUrl=40,
        GetUserSummaryUrl=41,
        GetUserCumulateUrl=42,
        GetArticleSummaryUrl=43,
        GetArticleTotalUrl=44,
        GetUserReadUrl=45,
        GetUserReadHourUrl=46,
        GetUserShareUrl=47,
        GetUserShareHourUrl=48,
        GetUpStreamMsgUrl=49,
        GetUpStreamMsgByHourUrl=50,
        GetUpStreamMsgByWeekUrl=51,
        GetUpStreamMsgByMonthUrl=52,
        GetUpStreamMsgDistUrl=53,
        GetUpStreamMsgDistByWeekUrl=54,
        GetUpStreamMsgDistByMonthUrl=55,
        GetInterfaceSummaryUrl=56,
        GetInterfaceSummaryByHourUrl=57,
        GetCardQrCodeUrl=58,
        CreateMaterialUrl=59,
        GetMaterialUrl=60,
        DeleteMaterialUrl=61,
        UpdateMaterialUrl=62,
        GetMaterialCountUrl=63,
        GetMaterialListUrl=64,
        UploadImgUrl=65,
        RegisterUrl=66,
        AuditStatusUrl=67,
        CreatePoiUrl=68,
        GetPoiUrl=69,
        GetPoiListUrl=70,
        UpdatePoiUrl=71,
        DeletePoiUrl=72,
        GetWxCategoryUrl=73,
        GetUserinfoUrl=74,
        GetAuthorizeUrl=75,
        GetAccessTokenByCodeUrl=76,
        GetsessionUrl=77,
        GetUserInfoListUrl=78,
        GetOpenidTokenUrl=79,
        GetDetailUserInfoUrl=80,
        GetRefershAccessTokenUrl=81,
        GetMediaUrl=82,
        GetPreviewUrl=83,
        InvitationCustomUrl=84,
        
    }
    public enum WechatScopeType
    {
        Base=1,
        UserInfo=2
    }
    public enum WechatResponseType
    {
        Code=1
    }
    public enum WechatMsgSearchType
    {
        [Description("默认匹配(全包含)")]
        None = 0,
        /// <summary>
        /// x=y
        /// </summary>
        [Description("精确匹配")]
        Equal = 1,
        /// <summary>
        /// x like y + '%'
        /// </summary>
        [Description("开头匹配")]
        StartWith=2,
        /// <summary>
        /// x like '%' + y
        /// </summary>
        [Description("结尾匹配")]
        EndWith=4,
        /// <summary>
        /// x like '%' + y + '%'
        /// </summary>
        [Description("关键词包含用户输入匹配")]
        Contain=8,
        /// <summary>
        /// y like '%' + x + '%'
        /// </summary>
        [Description("用户输入包含关键词匹配")]
        Include=16,
    }
    public enum ExcuteType
    {
        NoAccsess=0,
        Select = 1,
        Insert = 2,
        Update = 4,
        Delete = 8
    }
    public enum JobType
    {
        Assembly = 1,
        Sql =2,
        Web=3,
        WCF=4,
    }
}
