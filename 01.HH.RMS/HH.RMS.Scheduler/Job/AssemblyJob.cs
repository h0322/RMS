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
            Console.Write("StartJob:" + context.Trigger.Key.Name);
            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now;
            ResultType resultType = ResultType.Success;
            string resultMessage = "";
            var jobDataMap = context.MergedJobDataMap;
            var targetAssemblyFullName = jobDataMap.GetString(Config.jobAssemblyFullName);
            var targetAssemblyPath = jobDataMap.GetString(Config.jobAssemblyPath);
            var targetTypeFullName = jobDataMap.GetString(Config.jobAssembly);
            var targetMethodName = jobDataMap.GetString(Config.jobAssemblyMethod);
            var jobId = jobDataMap.GetLong(Config.jobId);
            var scheduleId = jobDataMap.GetLong(Config.schedulerId);
            var jobName = context.JobDetail.Key.Name;
            var jobGroupName = context.JobDetail.Key.Group;
            var scheduleName = context.Trigger.Key.Name;
            var scheduleGroupName = context.Trigger.Key.Group;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                var assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(m => m.FullName.ToLower().Equals(targetAssemblyFullName.ToLower()));
                if (assembly == null)
                {
                    assembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + targetAssemblyPath);
                }
                var type = assembly.GetType(targetTypeFullName);
                var obj = Activator.CreateInstance(type);
                var method = type.GetMethod(targetMethodName);
                var parameters = method.GetParameters().OrderBy(m => m.Position).ToList();
                var count = parameters.Count();
                var args = new object[count];
                for (int i = 0; i < count; i++)
                {
                    args[i] = jobDataMap.GetString(parameters[i].Name);
                }
                method.Invoke(obj, args);
                stopwatch.Stop();
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                resultType = ResultType.SystemError;
                resultMessage = ex.Message;
                log.Error("LocalObjectJob.Execute", ex);
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
                    scheduleGroup = scheduleGroupName,
                    scheduleName = scheduleName,
                    startTime = startTime,
                    endTime = endTime,
                    resultType = resultType,
                    resultMessage = resultMessage,
                    executeSecond = stopwatch.ElapsedMilliseconds
                });
            }
        }
    }
}
