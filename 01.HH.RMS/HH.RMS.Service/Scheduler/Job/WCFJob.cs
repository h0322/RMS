using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.IService.Scheduler;
using HH.RMS.IService.Scheduler.Model;
using HH.RMS.IService;
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
    public class WCFJob : JobBase, IJob
    {
        private IJobService _jobService;
        public WCFJob(IJobService jobService)
        {
            _jobService = jobService;
        }
        public WCFJob()
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
            try
            {
                //EndpointAddress address = new EndpointAddress(targetWCFURL);
                //BasicHttpBinding basicHttpBinding = new BasicHttpBinding();
                //basicHttpBinding.MaxBufferSize = 2147483647;
                //basicHttpBinding.MaxBufferPoolSize = 2147483647;
                //basicHttpBinding.MaxReceivedMessageSize = 2147483647;
                //basicHttpBinding.ReaderQuotas.MaxStringContentLength = 2147483647;
                //basicHttpBinding.CloseTimeout = new TimeSpan(2, 0, 0);
                //basicHttpBinding.OpenTimeout = new TimeSpan(2, 0, 0);
                //basicHttpBinding.ReceiveTimeout = new TimeSpan(2, 0, 0);
                //basicHttpBinding.SendTimeout = new TimeSpan(2, 0, 0);
                //using (ChannelFactory<IWechatWebService> channel = new ChannelFactory<IWechatWebService>(basicHttpBinding, address))
                //{
                //    IWechatWebService instance = channel.CreateChannel();
                //    Type type = typeof(IWechatWebService);
                //    MethodInfo method = type.GetMethod(targetMethodName);
                //    var paras = method.GetParameters().OrderBy(x => x.Position).ToList();
                //    var count = paras.Count();
                //    var args = new object[count];
                //    for (int i = 0; i < count; i++)
                //    {
                //        args[i] = jobDataMap.GetString(paras[i].Name);
                //    }

                //    method.Invoke(instance, args);
                //}

                //stopwatch.Stop();
                //periodBySecond = (int)stopwatch.ElapsedMilliseconds / 1000;
                //endTime = DateTime.Now;
                //resultCode = 1;
                //description = string.Format("WCFObjectJob: {0}: {1} successfully", targetWCFURL, targetMethodName);
                stopwatch.Start();
            }
            catch(Exception ex)
            {
                stopwatch.Stop();
                resultType = ResultType.SystemError;
                resultMessage = ex.Message;
                Config.log.Error("WCFJob.Execute", ex);
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
                    jobType = JobType.Assembly,
                    executeSecond = stopwatch.ElapsedMilliseconds
                });
                ConsoleEnd(jobName, resultType, resultMessage);
            }
        }
    }
}
