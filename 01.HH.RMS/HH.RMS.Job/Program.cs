using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Scheduler;
using log4net.Appender;

using log4net.Config;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using System.Linq.Expressions;
using Topshelf.Runtime;
using HH.RMS.Service;
namespace HH.RMS.Job
{
    class Program
    {

        static void Main(string[] args)
        {

            LogRegister();

            HostFactory.Run(x => 
            {
                x.Service<SchedulerManager>();
                x.RunAsLocalSystem();
                x.SetDescription(Configuration.serverDescription);
                x.SetDisplayName(Configuration.serverDisplayName);
                x.SetServiceName(Configuration.serverServiceName);
                //x.StartAutomatically();
            });  
            
        }
        public static void LogRegister()
        {
            string configfile = AppDomain.CurrentDomain.BaseDirectory + Configuration.configName;
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(configfile);
            XmlConfigurator.ConfigureAndWatch(fileInfo);
            ILoggerRepository hier = log4net.LogManager.GetRepository();
            if (hier != null)
            {
                foreach (log4net.Appender.IAppender appender in hier.GetAppenders())
                {
                    if (appender.Name != Configuration.logConfig)
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
