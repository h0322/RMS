using HH.RMS.Common.Constant;
using HH.RMS.Entity.Web;
using HH.RMS.Service.Web.Interface;
using HH.RMS.Common.Unity;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Scheduler
{
    public class SchedulerManager
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static IScheduler _iScheduler;
        private ISchedulerService _iSchedulerService;
        public SchedulerManager(ISchedulerService iSchedulerService)
        {
            _iSchedulerService = iSchedulerService;
        }
        //public static string contentString = "";
        public static void Start()
        {
            try
            {
                ISchedulerFactory schedulerFactory = new Quartz.Impl.StdSchedulerFactory();
                _iScheduler = schedulerFactory.GetScheduler();
                _iScheduler.Start();
                //启动任务
                
            }
            catch (Exception ex)
            {
                _log.Error("SchedulerManager.Start", ex);
            }

        }

        public static ResultType ExecuteScheduler(SchedulerEntity entity)
        {
            //通过反射得到Job类
            var type = Assembly.GetExecutingAssembly().GetType(entity.job.jobAssembly, false, true);
            if (type == null)
            {
                _log.Debug("SchedulerManager.Start:Job " + entity.job.jobAssembly + " Is Not Exists");
                return ResultType.NotExists;
            }
            try
            {
                var key = new JobKey(entity.scheduleName, entity.job.jobName);

                //根据Job类创建相应的Job
                IJobDetail jobDetail = JobBuilder.Create(type).WithIdentity(key).UsingJobData("data", entity.id).Build();
                //创建Trigger
                if (entity.intervalType == IntervalType.CronExpression)
                {
                    var trigger = TriggerBuilder.Create().WithIdentity(entity.scheduleName, entity.job.jobName).WithCronSchedule(entity.cronExpression).Build();
                    _iScheduler.ScheduleJob(jobDetail, trigger);
                }
                else
                {
                    //使得时分秒的方式
                    var cronExpression = SchedulerHelper.GetCronExpression(entity.intervalType, "0", entity.minute.ToString(), entity.hour.ToString(), entity.day.ToString(), entity.month.ToString(), entity.weekday.ToString(), entity.year.ToString());
                    var trigger = TriggerBuilder.Create().WithIdentity(entity.scheduleName, entity.job.jobName).WithCronSchedule(cronExpression).Build();
                    _iScheduler.ScheduleJob(jobDetail, trigger);
                }
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                _log.Error("SchedulerHelper.ExecuteScheduler", ex);
                return ResultType.SystemError;
            }
        }
        public static ResultType SimpleSchedule(Type type,int interval)
        {
            try
            {
                IJobDetail jobDetail = JobBuilder.Create(type).WithIdentity(type.Name, type.Namespace).Build();
                var trigger = TriggerBuilder.Create().WithIdentity(type.Name, type.Namespace).WithSimpleSchedule(m => m.RepeatForever().WithRepeatCount(0).WithIntervalInSeconds(interval)).Build();
                _iScheduler.ScheduleJob(jobDetail, trigger);
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                _log.Error("SchedulerManager.SimpleSchedule", ex);
                return ResultType.SystemError;
            }
        }

    }
}
