﻿using HH.RMS.Common.Constant;
using HH.RMS.Entity.Web;
using HH.RMS.Service.Web.Model;
using HH.RMS.Repository.EntityFramework;
using HH.RMS.Repository.EntityFramework.Interface;
using HH.RMS.Service.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HH.RMS.Service.Model;
using HH.RMS.Entity.Scheduler;
using HH.RMS.Service.Scheduler.Model;

namespace HH.RMS.Service.Web
{
    public class SchedulerService :ServiceBase, ISchedulerService
    {
        private IRepository<SchedulerEntity> _schedulerRepository;
        public SchedulerService(IRepository<SchedulerEntity> schedulerRepository)
        {
            _schedulerRepository = schedulerRepository;
        }

        public List<SchedulerModel> QueryRunningScheduler()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = from a in _schedulerRepository.Query(db)
                            where a.runTime <= DateTime.Now && a.stopTime >= DateTime.Now
                            select new SchedulerModel()
                            {
                                scheduleDescription=a.scheduleDescription,
                                scheduleName =a.scheduleName,
                                scheduleGroup =a.scheduleGroup,
                                cronExpression = a.cronExpression,
                                runTime = a.runTime,
                                stopTime = a.stopTime,
                                schedulerId = a.id,
                            };
                    return q.ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("SchedulerService.QueryRunningScheduler", ex);
                return null;
            }
        }
        //public ResultModel<SchedulerEntity> QuerySchedulerById(long schedulerId)
        //{
        //    ResultModel<SchedulerEntity> model = new ResultModel<SchedulerEntity>();
        //    SchedulerEntity entity;
        //    using (var db = new ApplicationDbContext())
        //    {
        //        entity = _iEFRepository.Find(db,schedulerId);
        //    }
        //    if (entity == null || !entity.isActive)
        //    {
        //        model.resultType = ResultType.NotExists;
        //        model.resultMsg = "Scheduler Not Exists";
        //        return model;
        //    }
        //    model.resultObj = entity;
        //    if (entity.runTime != null)
        //    {
        //        model.resultType = ResultType.Executed;
        //        model.resultMsg = "Scheduler Is Running";
        //        return model;
        //    }
        //    model.resultType = ResultType.Success;
        //    return model;
        //}
    }
}