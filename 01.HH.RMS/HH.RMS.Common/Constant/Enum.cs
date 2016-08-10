using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Common.Constant
{
    public enum LevelType
    {
        level1=1,
        level2=2
    }
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
        SystemError = 500,
    }
    public enum IntervalType
    {
        CronExpression = 0,
        OnlyOnce = 1,
        Daily = 2,
        Weekly = 3,
        Monthly = 4,
        Yearly = 5,
    }
    public enum SqlScriptType
    {
        SqlString=1,
        Procedure=2
    }
    public enum AccountStatusType
    {
        Normal =0,
        Disable =1,
        Black=2
    }
    public enum RoleType
    {
        [DescriptionAttribute("系统管理员")]
        Admin=1,
        [DescriptionAttribute("超级用户")]
        SuperUser=2,
        [DescriptionAttribute("普通会员")]
        NormalUser=3
    }
    public enum ObjectType
    { 
        Object=1,
        List=2
     }
    public enum MenuType
    {
        menu1=1
    }
}
