using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Service.Scheduler.Model;
using HH.RMS.Service.Web.Interface;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Scheduler.Job
{
    public class AssemblyJob : JobBase,IJob
    {
        private IJobService _jobService;
        public AssemblyJob(IJobService jobService)
        {
            _jobService = jobService;
        }
        public AssemblyJob()
            : this(UnityManager.instance.GetService<IJobService>())
        { }
        public void Execute(IJobExecutionContext context)
        {
            ConsoleBegin(context.JobDetail.Key.Name.ToString());
            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now;
            ResultType resultType = ResultType.Success;
            string resultMessage = "";
            var jobDataMap = context.MergedJobDataMap;
            var jobAssemblyFullName = jobDataMap.GetString(Config.jobAssemblyFullName);
            var jobAssemblyPath = jobDataMap.GetString(Config.jobAssemblyPath);
            var jobAssembly = jobDataMap.GetString(Config.jobAssembly);
            var jobAssemblyMethod = jobDataMap.GetString(Config.jobAssemblyMethod);
            var jobId = jobDataMap.GetLong(Config.jobId);
            var scheduleId = jobDataMap.GetLong(Config.schedulerId);
            var jobName = context.JobDetail.Key.Name;
            var jobGroupName = context.JobDetail.Key.Group;
            var scheduleName = context.Trigger.Key.Group;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                var assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(m => m.FullName.ToLower().Equals(jobAssemblyFullName.ToLower()));
                if (assembly == null)
                {
                    assembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + jobAssembly);
                }
                var type = assembly.GetType(jobAssemblyPath);
                var obj = Activator.CreateInstance(type);
                var method = type.GetMethod(jobAssemblyMethod);
                var jobParameterList = _jobService.QueryJobParameterByJobId(jobId);
                object[] args = null;
                if (jobParameterList != null)
                {
                    args = new object[jobParameterList.Count];
                    for (int i = 0; i < jobParameterList.Count; i++)
                    {
                        switch (jobParameterList[i].parameterType)
                        {
                            case DataType.Int32:
                                args[i] = Convert.ToInt32(jobParameterList[i].parameterValue);
                                break;
                            case DataType.Int64:
                                args[i] = Convert.ToInt64(jobParameterList[i].parameterValue);
                                break;
                            case DataType.Decimal:
                                args[i] = Convert.ToDecimal(jobParameterList[i].parameterValue);
                                break;
                            case DataType.Double:
                                args[i] = Convert.ToDouble(jobParameterList[i].parameterValue);
                                break;
                            case DataType.DateTime:
                                args[i] = Convert.ToDateTime(jobParameterList[i].parameterValue);
                                break;
                            case DataType.Boolean:
                                args[i] = Convert.ToBoolean(jobParameterList[i].parameterValue);
                                break;
                            default:
                                args[i] = jobParameterList[i].parameterValue;
                                break;
                        }

                    }
                }

                method.Invoke(obj, args);
                stopwatch.Stop();
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                resultType = ResultType.SystemError;
                resultMessage = ex.Message;
                Config.log.Error("AssemblyJob.Execute", ex);
            }
            finally
            {
                endTime = DateTime.Now;
                _jobService.InsertJobLog(new JobLogModel()
                {
                    jobId= jobId,
                    schedulerId = scheduleId,
                    jobName = jobName,
                    jobGroup = jobGroupName,
                    scheduleName = scheduleName,
                    startTime = startTime,
                    endTime = endTime,
                    resultType = resultType,
                    resultMessage = resultMessage,
                    jobType = JobType.Assembly,
                    executeSecond = stopwatch.ElapsedMilliseconds
                });
                ConsoleEnd(jobName, resultType, resultMessage);
            }
        }
    }
}
