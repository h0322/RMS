using HH.RMS.Common.Constant;
using log4net.Appender;
using log4net.Config;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HH.RMS.MVC
{
    public class Log4NetConfig
    {
        public static void Register(HttpApplication context)
        {
            string configfile = context.Server.MapPath("~") + "\\web.config";
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(configfile);
            XmlConfigurator.ConfigureAndWatch(fileInfo);
            ILoggerRepository hier = log4net.LogManager.GetRepository();
            if (hier != null)
            {
                foreach (log4net.Appender.IAppender appender in hier.GetAppenders())
                {
                    if (appender.Name != "ADONetAppender")
                    {
                        continue;
                    }
                    AdoNetAppender adoAppender = (AdoNetAppender)appender;
                    adoAppender.ConnectionString = Config.sqlLogConnStr;
                    //refresh settings of appender
                    adoAppender.ActivateOptions();
                }
            }
        }
    }
}