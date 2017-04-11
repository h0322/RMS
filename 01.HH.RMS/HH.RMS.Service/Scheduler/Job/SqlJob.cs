using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Repository;
using HH.RMS.IService.Scheduler.Model;
using HH.RMS.IService;
using Quartz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HH.RMS.IService.Scheduler;

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
            var jobCommandType = jobDataMap.GetInt(Config.jobCommandType);
            var jobId = jobDataMap.GetLong(Config.jobId);
            var scheduleId = jobDataMap.GetLong(Config.schedulerId);
            var jobName = context.JobDetail.Key.Name;
            var jobGroupName = context.JobDetail.Key.Group;
            var scheduleName = context.Trigger.Key.Group;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var jobParameterList = _jobService.QueryJobParameterByJobId(jobId);
            SqlParameter[] sqlParameters = new SqlParameter[jobParameterList.Count];
            if (jobParameterList != null)
            {
                for (int i = 0; i < jobParameterList.Count; i++)
                {
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter.Value = jobParameterList[i].parameterValue;
                    switch (jobParameterList[i].parameterType)
                    {
                        case DataType.Int32:
                            sqlParameter.SqlDbType = SqlDbType.Int;
                            break;
                        case DataType.Int64:
                            sqlParameter.SqlDbType = SqlDbType.BigInt;
                            break;
                        case DataType.Decimal:
                            sqlParameter.SqlDbType = SqlDbType.Decimal;
                            break;
                        case DataType.Double:
                            sqlParameter.SqlDbType = SqlDbType.Float;
                            break;
                        case DataType.DateTime:
                            sqlParameter.SqlDbType = SqlDbType.DateTime;
                            break;
                        case DataType.Boolean:
                            sqlParameter.SqlDbType = SqlDbType.Bit;
                            break;
                        default:
                            sqlParameter.SqlDbType = SqlDbType.NVarChar;
                            break;
                    }
                    sqlParameters[i] = sqlParameter;
                }
            }
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.Database.CommandTimeout = 60000;
                    db.Database.ExecuteSqlCommand(jobCommandText, sqlParameters);
                }
                stopwatch.Stop();
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                resultType = ResultType.SystemError;
                resultMessage = ex.Message;
                Config.log.Error("SqlJob.Execute", ex);
                
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
