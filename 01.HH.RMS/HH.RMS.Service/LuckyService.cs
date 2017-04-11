using HH.RMS.Common.Constant;
using HH.RMS.Entity;
using HH.RMS.Repository;
using HH.RMS.Repository.Interface;
using HH.RMS.IService;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using HH.RMS.Common.Model;

namespace HH.RMS.Service
{
    public class LuckyService:ILuckyService
    {
        private IRepository<LuckyDrawEntity> _luckyDrawRepository { get; set; }
        private IRepository<LuckyPrizeEntity> _luckyPrizeRepository { get; set; }
        private IRepository<LuckyLogEntity> _luckyLogRepository { get; set; }
        private IRepository<LuckyResultEntity> _luckyResultRepository { get; set; }
        public LuckyService(IRepository<LuckyResultEntity> luckyResultRepository,IRepository<LuckyDrawEntity> luckyDrawRepository, IRepository<LuckyPrizeEntity> luckyPrizeRepository, IRepository<LuckyLogEntity> luckyLogRepository)
        {
            _luckyDrawRepository = luckyDrawRepository;
            _luckyLogRepository = luckyLogRepository;
            _luckyPrizeRepository = luckyPrizeRepository;
            _luckyResultRepository = luckyResultRepository;
        }
        #region LuckyDraw
        public virtual ResultModel<LuckyPrizeModel> LuckyDraw(long accountId, long luckyDrawId)
        {
            //List<LuckyPrizeModel> luckyPrizeList = QueryLuckyPrizeByLuckyDrawId(luckyDrawId).OrderBy(m=>m.rate).ToList();
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var luckyPrizeList = _luckyPrizeRepository.Query(db).Where(m => m.luckyDrawId == luckyDrawId).ToList();
                    if (luckyPrizeList == null)
                    {
                        return new ResultModel<LuckyPrizeModel>(ResultType.NotExists, null, "奖品不存在");
                    }
                    if (luckyPrizeList.Sum(m => m.rate) != 100)
                    {
                        return new ResultModel<LuckyPrizeModel>(ResultType.FieldError, null, "奖品配置不正确");
                    }
                    decimal rate = 0;
                    int random = new Random().Next(0, 100);
                    foreach (var item in luckyPrizeList)
                    {
                        rate += item.rate;
                        if (random < rate && item.leftCount > 0)
                        {
                            //InsertLuckyLog(new LuckyLogModel() { accountId = accountId, luckyDrawId = luckyDrawId, luckyPrizeId = item.id });
                            LuckyLogEntity luckyLogEntity = new LuckyLogEntity();
                            luckyLogEntity.accountId = accountId;
                            luckyLogEntity.luckyDrawId = luckyDrawId;
                            luckyLogEntity.luckyPrizeId = item.id;
                            using (TransactionScope transaction = new TransactionScope())
                            {
                                if (item.isLimited)
                                {
                                    item.leftCount--;
                                    _luckyPrizeRepository.Update(db, item);
                                }
                                _luckyLogRepository.Insert(db, luckyLogEntity);
                                transaction.Complete();
                                return new ResultModel<LuckyPrizeModel>(ResultType.Success, LuckyPrizeModel.ModelMapper<LuckyPrizeModel>(item));
                            }

                        }

                    }
                    return new ResultModel<LuckyPrizeModel>(ResultType.Fail, null, "奖品异常");
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("LuckyService.LuckyDraw", ex);
                return new ResultModel<LuckyPrizeModel>(ResultType.SystemError,null, "奖品异常");
            }
        }
        public ResultType InsertLuckyDraw(LuckyPrizeModel model)
        {
            var entity = LuckyDrawModel.EntityMapper<LuckyDrawEntity>(model);
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    int result = _luckyDrawRepository.Insert(db, entity);
                    if (result > 0)
                    {
                        return ResultType.Success;
                    }
                    return ResultType.Fail;
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("LuckyService.InsertLuckyLog", ex);
                return ResultType.SystemError;
            }
        }

        #endregion

        #region LuckyPrize
        public List<LuckyPrizeModel> QueryLuckyPrizeByLuckyDrawId(long id)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var list = _luckyPrizeRepository.Query(db).Where(m => m.luckyDrawId == id).ToList();
                    return LuckyPrizeModel.ModelMapper<List<LuckyPrizeModel>>(list);
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("LuckyService.QueryLuckyPrizeByLuckyDrawId", ex);
                return null;
            }
        }
        public ResultType InsertLuckyPrize(LuckyPrizeModel model)
        {
            var entity = LuckyPrizeModel.EntityMapper<LuckyPrizeEntity>(model);
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    int result = _luckyPrizeRepository.Insert(db, entity);
                    if (result > 0)
                    {
                        return ResultType.Success;
                    }
                    return ResultType.Fail;
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("LuckyService.InsertLuckyLog", ex);
                return ResultType.SystemError;
            }
        }
        #endregion

        #region LuckyLog
        public List<LuckyLogModel> QueryLuckyLogByLuckyDrawId(long id)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var list = _luckyLogRepository.Query(db).Where(m => m.luckyDrawId == id).ToList();
                    return LuckyLogModel.ModelMapper<List<LuckyLogModel>>(list);
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("LuckyService.QueryLuckLogByLuckyDrawId", ex);
                return null;
            }
        }
        public ResultType InsertLuckyLog(LuckyLogModel model)
        {
            var entity = LuckyLogModel.EntityMapper<LuckyLogEntity>(model);
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    //StringBuilder sqlBuilder = new StringBuilder();
                    //sqlBuilder.Append(" Begin Tran");
                    //sqlBuilder.Append(" if exists (select 1 from [LuckyPrize] where id= @LuckyPrizeId and isLimited = 0");
                    //sqlBuilder.Append(" begin");
                    //sqlBuilder.Append(" UPDATE [LuckyPrize]");
                    //sqlBuilder.Append(" SET [leftCount] =[leftCount]-1");
                    //sqlBuilder.Append(" WHERE id= @LuckyPrizeId and [leftCount]>0");
                    //sqlBuilder.Append(" if(@@rowcount=0)");
                    //sqlBuilder.Append(" begin");
                    //sqlBuilder.Append(" return");
                    //sqlBuilder.Append(" end");
                    //sqlBuilder.Append(" end");
                    //sqlBuilder.Append(" INSERT INTO [LuckyLog]");
                    //sqlBuilder.Append(" ([accountId] ,[LuckyDrawId] ,[LuckyPrizeId] ,[placeId] ,[createBy] ,[updateBy] ,[createTime]  ,[updateTime]  ,[remark] ,[isActive])");
                    //sqlBuilder.Append(" VALUES");
                    //sqlBuilder.Append(" (@accountId, @LuckyDrawId, @LuckyPrizeId, @placeId, @createBy, @updateBy, @createTime, @updateTime, @remark, @isActive)");
                    //sqlBuilder.Append(" Commit Tran");
                    //SqlParameter[] sqlPara =new SqlParameter[]
                    //{
                    //    new SqlParameter("@accountId",model.accountId),
                    //    new SqlParameter("@LuckyDrawId",model.luckyDrawId),
                    //    new SqlParameter("@LuckyPrizeId",model.luckyDrawId),
                    //    new SqlParameter("@placeId",model.placeId),
                    //    new SqlParameter("@createBy",0),
                    //    new SqlParameter("@updateBy",0),
                    //    new SqlParameter("@createTime",DateTime.Now.ToString("yyyy-MM-dd")),
                    //    new SqlParameter("@updateTime",DateTime.Now.ToString("yyyy-MM-dd")),
                    //    new SqlParameter("@remark",model.remark),
                    //    new SqlParameter("@isActive",true),
                    //};
                    //int result = _luckyLogRepository.ExecuteSql(db, sqlBuilder.ToString(), sqlPara);
                    //if (result > 0)
                    //{
                    //    return ResultType.Success;
                    //}
                    //return ResultType.Fail;
                    int result = _luckyLogRepository.Insert(db,entity);
                    if (result > 0)
                    {
                        return ResultType.Success;
                    }
                    return ResultType.Fail;
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("LuckyService.InsertLuckyLog", ex);
                return ResultType.SystemError;
            }
        }
        #endregion

        #region LuckyResult
        public ResultType InsertLuckyResult(LuckyResultModel model)
        {
            var entity = LuckyResultModel.EntityMapper<LuckyResultEntity>(model);
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    int result = _luckyResultRepository.Insert(db, entity);
                    if (result > 0)
                    {
                        return ResultType.Success;
                    }
                    return ResultType.Fail;
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("LuckyService.InsertLuckyLog", ex);
                return ResultType.SystemError;
            }
        }
        public List<LuckyResultModel> QueryLuckyResultByLuckyDrawId(long id)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var list = _luckyResultRepository.Query(db).Where(m => m.luckyDrawId == id).ToList();
                    return LuckyResultModel.ModelMapper<List<LuckyResultModel>>(list);
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("LuckyService.QueryLuckLogByLuckyDrawId", ex);
                return null;
            }
        }
        #endregion
    }
}
