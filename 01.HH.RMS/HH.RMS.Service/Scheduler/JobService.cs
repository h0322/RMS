using HH.RMS.Common.Constant;
using HH.RMS.Entity.Scheduler;
using HH.RMS.Repository.EntityFramework;
using HH.RMS.Repository.EntityFramework.Interface;
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
    public class JobService : ServiceBase, IJobService
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
                    JobModel.ModelMapper();
                    var jobList = _jobRepository.Query(db).Where(m => m.fromDate <= DateTime.Now && m.toDate >= DateTime.Now).ToList();
                    return TinyMapper.Map<List<JobModel>>(jobList);
                }
            }
            catch (Exception ex)
            {
                return null;
                log.Error("JobService.QueryRunningJobBy", ex);
            }
        }

        public List<JobModel> QueryRunningJobBySchedulerId(long id)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    JobModel.ModelMapper();
                    var jobList = _jobRepository.Query(db).Where(m => m.fromDate <= DateTime.Now && m.toDate >= DateTime.Now && m.schedulerId == id).ToList();
                    return  TinyMapper.Map<List<JobModel>>(jobList);
                }
            }
            catch (Exception ex)
            {
                return null;
                log.Error("JobService.QueryRunningJobBySchedulerId", ex);
            }
        }

        public List<JobParameterModel> QueryJobParameterByJobId(long id)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var list = _jobParameterRepository.Query(db).Where(m=>m.jobId==id).ToList();
                    return TinyMapper.Map<List<JobParameterModel>>(list);
                }
            }
            catch (Exception ex)
            {
                return null;
                log.Error("JobService.QueryJobParameterByJobId", ex);
            }
        }
        public ResultType InsertJobLog(JobLogModel model)
        {
            try
            {
                JobModel.EntityMapper();
                JobLogEntity logEntity = TinyMapper.Map<JobLogEntity>(model);
                using (var db = new ApplicationDbContext())
                {
                    _jobLogRepository.Insert(db, logEntity);
                }
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                log.Error("JobService.InsertJobLog", ex);
                return ResultType.SystemError;
            }
        }
    }
}
