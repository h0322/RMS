﻿using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.IService.Scheduler;
using HH.RMS.IService.Scheduler.Model;
using HH.RMS.IService;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Scheduler.Job
{
    public class WebJob : JobBase, IJob
    {
        private IJobService _jobService;
        public WebJob(IJobService jobService)
        {
            _jobService = jobService;
        }
        public WebJob()
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
            var jobUrl = jobDataMap.GetString(Config.jobUrl);
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
                if (string.IsNullOrEmpty(jobUrl))
                {
                    Config.log.Info("WebJob.Execute:Job Url Is NULL;JobID:" + jobId);
                    return;
                }
                HttpWebRequest httpWebRequest = (HttpWebRequest)System.Net.WebRequest.Create(jobUrl);
                httpWebRequest.UseDefaultCredentials = true;
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                resultType = ResultType.SystemError;
                resultMessage = ex.Message;
                Config.log.Error("WebJob.Execute", ex);
                
            }
            finally {
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
                    jobType = JobType.Web,
                    executeSecond = stopwatch.ElapsedMilliseconds
                });
                ConsoleEnd(jobName, resultType, resultMessage);
            }
        }
    }
}
