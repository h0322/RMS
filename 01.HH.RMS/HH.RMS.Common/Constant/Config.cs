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
        public static string emailSender = Utilities.ConfigHelper.GetConfigString("EmailSender");
        public static string emailSenderPwd = Utilities.ConfigHelper.GetConfigString("EmailSenderPwd");
        public static string smtpServer = Utilities.ConfigHelper.GetConfigString("SmtpServer");
        public static string serverName = Utilities.ConfigHelper.GetConfigString("ServerName");
        public static string siteName = Utilities.ConfigHelper.GetConfigString("SiteName");
        public readonly static string loginSession = "AccountDetailsSession";
        public readonly static string menuSession = "SystemMenusSession";
    }
}
