using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Repository.EntityFramework;
using HH.RMS.Service.Scheduler.Model;
using HH.RMS.Service.Web.Interface;
using Quartz;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Scheduler.Job
{
    public class SqlJob : JobBase, IJob
    {
        private IJobService _jobService;
         public SqlJob(IJobService jobService)
        {
            _jobService = jobService;
        }
        public SqlJob()
            : this(UnityManager.instance.GetService<IJobService>())
        { }
        public void Execute(IJobExecutionContext context)
        {
            ConsoleBegin(context.JobDetail.Key.Name);
            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now;
            ResultType resultType = ResultType.Success;
            string resultMessage = "";
            var jobDataMap = context.MergedJobDataMap;
            var jobCommandText = jobDataMap.GetString(Config.jobCommandText);
            var jobCommandType = jobDataMap.GetString(Config.jobCommandType);
            var jobId = jobDataMap.GetLong(Config.jobId);
            var scheduleId = jobDataMap.GetLong(Config.schedulerId);
            var jobName = context.JobDetail.Key.Name;
            var jobGroupName = context.JobDetail.Key.Group;
            var scheduleName = context.Trigger.Key.Name;
            var scheduleGroupName = context.Trigger.Key.Group;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var jobParameterList = _jobService.QueryJobParameterByJobId(jobId);
            var args = new object[jobParameterList.Count];
            SqlParameter[] sqlParameters = new SqlParameter[] { };
            if (jobParameterList != null)
            {
                for (int i = 0; i < jobParameterList.Count; i++)
                {
                    sqlParameters[i].Value = jobParameterList[i].parameterValue;
                }
            }
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.Database.ExecuteSqlCommand(jobCommandText, sqlParameters);
                }
                stopwatch.Stop();
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                resultType = ResultType.SystemError;
                resultMessage = ex.Message;
                log.Error("SqlJob.Execute", ex);
                
            }
            finally
            {
                endTime = DateTime.Now;
                _jobService.InsertJobLog(new JobLogModel()
                {
                    jobId = jobId,
                    schedulerId = scheduleId,
                    jobName = jobName,
                    jobGroup = jobGroupName,
                    scheduleGroup = scheduleGroupName,
                    scheduleName = scheduleName,
                    startTime = startTime,
                    endTime = endTime,
                    resultType = resultType,
                    resultMessage = resultMessage,
                    jobType = JobType.Sql,
                    executeSecond = stopwatch.ElapsedMilliseconds
                });
                ConsoleEnd(jobName, resultType, resultMessage);
            }
        }
    }
}
