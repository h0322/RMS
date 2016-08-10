using HH.RMS.Common.Constant;
using HH.RMS.Entity;
using HH.RMS.Model;
using HH.RMS.Repository.EntityFramework;
using HH.RMS.Repository.EntityFramework.Interface;
using HH.RMS.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service
{
    public class SchedulerService : ISchedulerService
    {
        private IRepository<SchedulerEntity> _iEFRepository;
        public SchedulerService(IRepository<SchedulerEntity> iEFRepository)
        {
            _iEFRepository = iEFRepository;
        }

        public List<SchedulerEntity> QuerySchedulerAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return _iEFRepository.Query(db,"job").ToList();
            }
        }
        public ResultModel<SchedulerEntity> QuerySchedulerById(long schedulerId)
        {
            ResultModel<SchedulerEntity> model = new ResultModel<SchedulerEntity>();
            SchedulerEntity entity;
            using (var db = new ApplicationDbContext())
            {
                entity = _iEFRepository.Find(db,schedulerId);
            }
            if (entity == null || !entity.isActive)
            {
                model.resultType = ResultType.NotExists;
                model.resultMsg = "Scheduler Not Exists";
                return model;
            }
            model.resultObj = entity;
            if (entity.runTime != null)
            {
                model.resultType = ResultType.Executed;
                model.resultMsg = "Scheduler Is Running";
                return model;
            }
            model.resultType = ResultType.Success;
            return model;
        }
    }
}
