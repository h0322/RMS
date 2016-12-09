using HH.RMS.Common.Constant;
using HH.RMS.Entity.Scheduler;
using HH.RMS.Entity.EntityFramework;
using HH.RMS.Entity.EntityFramework.Interface;
using HH.RMS.Service.Model;
using HH.RMS.Service.Scheduler.Model;
using HH.RMS.Service.Web.Interface;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web
{
    public class JobService :  IJobService
    {
        private IRepository<JobEntity> _jobRepository;
        private IRepository<JobParameterEntity> _jobParameterRepository;
        private IRepository<JobLogEntity> _jobLogRepository;
        public JobService(IRepository<JobEntity> jobRepository, IRepository<JobParameterEntity> jobParameterRepository, IRepository<JobLogEntity> jobLogRepository)
        {
            _jobRepository = jobRepository;
            _jobParameterRepository = jobParameterRepository;
            _jobLogRepository = jobLogRepository;
        }
        public List<JobModel> QueryRunningJob()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var jobList = _jobRepository.Query(db).Where(m => m.fromDate <= DateTime.Now && m.toDate >= DateTime.Now).ToList();
                    return TinyMapper.Map<List<JobModel>>(jobList); //TinyMapper.Map<List<JobModel>>(jobList);
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("JobService.QueryRunningJobBy", ex);
                return null;
            }
        }

        public List<JobModel> QueryRunningJobBySchedulerId(long id)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var jobList = _jobRepository.Query(db).Where(m => m.fromDate <= DateTime.Now && m.toDate >= DateTime.Now && m.schedulerId == id).ToList();
                    return TinyMapper.Map<List<JobModel>>(jobList);//JobModel.ModelMapper<List<JobModel>>(jobList);
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("JobService.QueryRunningJobBySchedulerId", ex);
                return null;
            }
        }

        public List<JobParameterModel> QueryJobParameterByJobId(long id)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var list = _jobParameterRepository.Query(db).Where(m=>m.jobId==id).ToList();
                    return TinyMapper.Map<List<JobParameterModel>>(list);//TinyMapper.Map<List<JobParameterModel>>(list);
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("JobService.QueryJobParameterByJobId", ex);
                return null;
            }
        }
        public ResultType InsertJobLog(JobLogModel model)
        {
            try
            {
                JobLogEntity logEntity = TinyMapper.Map<JobLogEntity>(model);
                using (var db = new ApplicationDbContext())
                {
                    _jobLogRepository.Insert(db, logEntity);
                }
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                Config.log.Error("JobService.InsertJobLog", ex);
                return ResultType.SystemError;
            }
        }
    }
}
