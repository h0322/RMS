using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Scheduler;
using HH.RMS.Service.Web.Interface;
using log4net.Appender;
using log4net.Config;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Job
{
    class Program
    {
        public const string configName = "\\HH.RMS.Job.exe.config";
        static void Main(string[] args)
        {
            LogRegister();
            new UnityScheduler(UnityManager.instance);
            SchedulerManager manager = new SchedulerManager();
            manager.Initialize();
            
            Console.Write("Job Excetue");
        }
        public static void LogRegister()
        {
            string configfile = AppDomain.CurrentDomain.BaseDirectory + configName;
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
                    adoAppender.ConnectionString = Config.sqlConnStr;
                    adoAppender.ActivateOptions();
                }
            }
        }
    }
}
