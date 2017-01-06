using HH.RMS.Common.Constant;
using HH.RMS.Entity.Web;
using HH.RMS.Service.Web.Model;
using HH.RMS.Repository;
using HH.RMS.Repository.Interface;
using HH.RMS.Service.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HH.RMS.Service.Model;
using HH.RMS.Entity.Scheduler;
using HH.RMS.Service.Scheduler.Model;
using System.Linq.Expressions;

namespace HH.RMS.Service.Web
{
    public class SchedulerService : ISchedulerService
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
                Config.log.Error("SchedulerService.QueryRunningScheduler", ex);
                return null;
            }
        }
        public ResultType DeleteSchedulerById(long id)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                   int result = _schedulerRepository.Update(db, _schedulerRepository.DeleteEntity(), m => m.id == id);
                   if (result > 0)
                   {
                       return ResultType.Success;
                   }
                   else
                   {
                       return ResultType.Fail;
                   }
                }
                
            }
            catch (Exception ex)
            {
                Config.log.Error("SchedulerService.DeleteSchedulerById", ex);
                return ResultType.Fail;
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
