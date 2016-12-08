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
        Unknow = 0,
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
        FieldError=13,
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
        Normal = 1,
        Disable = 2,
        Black = 3,
        
    }
    public enum PasswordType
    {
        Normal =1,
        ResetPwd = 2
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
    public enum WechatSubscribeType
    {
        Unsubscribe=0,
        Subscribe=1,
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
    public enum PrizeType
    {
        Score=1,
        Material=2,
        Cash=3
    }
    public enum EncodeType
    {
        UTF8=1,
        GB=2,
        Other=99
    }
    public enum EmailSendStatus
    {
        Success=0,
        Fail=1,
        Sending=2
    }
    public enum VideoStatus
    {
        play=1
    }
    public enum PlayerType
    {
        youku=1,
        qq=2,
        leshi=3,
        pptv=4,
        sohu=5
    }
}
