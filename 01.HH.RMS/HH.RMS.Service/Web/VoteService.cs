using HH.RMS.Common.Constant;
using HH.RMS.Entity.Web;
using HH.RMS.Repository.EntityFramework;
using HH.RMS.Repository.EntityFramework.Interface;
using HH.RMS.Service.Model;
using HH.RMS.Service.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web
{
    public class VoteService : IVoteService
    {
        private IRepository<VoteEntity> _voteRepository { get; set; }
        private IRepository<VoteBoxEntity> _voteBoxRepository { get; set; }
        private IRepository<VoteLogEntity> _voteLogRepository { get; set; }
        public VoteService(IRepository<VoteEntity> voteRepository, IRepository<VoteBoxEntity> voteBoxRepository, IRepository<VoteLogEntity> voteLogRepository)
        {
            _voteRepository = voteRepository;
            _voteBoxRepository = voteBoxRepository;
            _voteLogRepository = voteLogRepository;
        }
        #region VoteBox

        public List<VoteBoxModel> QueryVoteBoxByVoteId(long voteId)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var list = _voteBoxRepository.Query(db).Where(m => m.voteId == voteId).ToList();
                    return VoteBoxModel.ModelMapper<List<VoteBoxModel>>(list);
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("VoteService.QueryVoteBoxByVoteId", ex);
                return null;
            }
        }
        public ResultType InsertVoteBox(VoteBoxModel model)
        {
            try
            {
                var entity = VoteBoxModel.ModelMapper<VoteBoxEntity>(model);
                using (var db = new ApplicationDbContext())
                {
                    var result = _voteBoxRepository.Insert(db,entity);
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
                Config.log.Error("VoteService.QueryVoteBoxByVoteId", ex);
                return ResultType.SystemError;
            }
        }
        #endregion


        #region Vote
        public virtual ResultType Vote(long accountId,long voteId)
        {
            return ResultType.Success;
        }
        public List<VoteModel> QueryVote()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var list = _voteRepository.Query(db).ToList();
                    return VoteModel.ModelMapper<List<VoteModel>>(list);
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("VoteService.QueryVoteBoxByVoteId", ex);
                return null;
            }
        }
        public ResultType InsertVote(VoteModel model)
        {
            try
            {
                var entity = VoteModel.ModelMapper<VoteEntity>(model);
                using (var db = new ApplicationDbContext())
                {
                    var result = _voteRepository.Insert(db, entity);
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
                Config.log.Error("VoteService.QueryVoteBoxByVoteId", ex);
                return ResultType.SystemError;
            }
        }
        #endregion

        #region VoteLog
        public List<VoteLogModel> QueryVoteLog()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var list = _voteLogRepository.Query(db).ToList();
                    return VoteLogModel.ModelMapper<List<VoteLogModel>>(list);
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("VoteService.QueryVoteBoxByVoteId", ex);
                return null;
            }
        }
        public ResultType InsertVoteLog(VoteLogModel model)
        {
            try
            {
                var entity = VoteLogModel.ModelMapper<VoteLogEntity>(model);
                using (var db = new ApplicationDbContext())
                {
                    var result = _voteLogRepository.Insert(db, entity);
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
                Config.log.Error("VoteService.QueryVoteBoxByVoteId", ex);
                return ResultType.SystemError;
            }
        }
        #endregion
    }
}
