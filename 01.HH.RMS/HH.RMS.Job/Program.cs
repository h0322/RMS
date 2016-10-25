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
using Topshelf.Runtime;

namespace HH.RMS.Job
{
    class Program
    {
        public const string configName = "\\HH.RMS.Job.exe.config";
        static void Main(string[] args)
        {
            LogRegister();
            new UnityScheduler(UnityManager.instance);
            //SchedulerManager manager = new SchedulerManager();
            //manager.Initialize();
            //var host = HostFactory.New(x =>
            //{
            //    x.RunAsLocalSystem();

            //    x.SetDescription("SampleService Description");
            //    x.SetDisplayName("SampleService");
            //    x.SetServiceName("SampleService");

            //    x.Service(factory =>
            //    {
            //        SchedulerManager manager = new SchedulerManager();
            //        manager.Initialize();
            //        return ;
            //    });


            //});

            //host.Run();

            HostFactory.Run(x =>                                 //1
            {
                x.Service<SchedulerManager>();
                x.RunAsLocalSystem();                            //6

                x.SetDescription("Sample Topshelf Host");        //7
                x.SetDisplayName("Stuff");                       //8
                x.SetServiceName("Stuff");                       //9
            });  
            Console.Write("Job Excetue...");
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
