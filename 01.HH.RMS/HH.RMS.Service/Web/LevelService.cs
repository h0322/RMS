using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity.Web;
using HH.RMS.Repository.EntityFramework;
using HH.RMS.Repository.EntityFramework.Interface;
using HH.RMS.Service.Web.Interface;
using HH.RMS.Service.Web.Model;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web
{
    public class LevelService :  ILevelService
    {
        private IRepository<LevelEntity> _levelRepository;
        public LevelService(IRepository<LevelEntity> levelRepository)
        {
            _levelRepository = levelRepository;

        }

        public GridModel QueryLevelToGrid(PagerModel pager)
        {
            try
            {
                    List<LevelModel> list = null;
                    if (pager != null)
                    {
                        list = LevelModel.CurrentCacheList.OrderByDescending(m => m.id).Take(pager.rows * pager.page).Skip(pager.rows * (pager.page - 1)).ToList();
                    }
                    GridModel gridModel = new GridModel()
                    {
                        rows = list,
                        total = LevelModel.CurrentCacheList.Count()
                    };
                    return gridModel;
            }
            catch (Exception ex)
            {
                Config.log.Error("LevelService.QueryLevelToGrid", ex);
                return null;
            }
        }
        public List<LevelModel> QueryLevelList()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var list = _levelRepository.Query(db).ToList();
                    return TinyMapper.Map<List<LevelModel>>(list);
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("LevelService.QueryLevelList", ex);
                return null;
            }
        }
        public ResultType CreateLevel(LevelModel model)
        {
            try {
                var entity = TinyMapper.Map<LevelEntity>(model);
                using (var db = new ApplicationDbContext())
                {
                    _levelRepository.Insert(db, entity);
                    CacheHelper.RemoveCache(Config.levelCache);
                    return ResultType.Success;
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("LevelService.InserLevel", ex);
                return ResultType.SystemError;
            }
 
        }

        public ResultType UpdateLevel(LevelModel model)
        {
            try
            {
                var entity = TinyMapper.Map<LevelEntity>(model);
                using (var db = new ApplicationDbContext())
                {
                    _levelRepository.Update(db, m => new LevelEntity()
                    {
                        levelName = model.levelName,
                        levelOrder = model.levelOrder,
                        remark = model.remark ?? "",
                        updateBy = AccountModel.CurrentSession.id,
                        updateTime = DateTime.Now
                    }, m => m.id == model.id);
                }
                CacheHelper.RemoveCache(Config.levelCache);
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                Config.log.Error("LevelService.UpdateLevel", ex);
                return ResultType.SystemError;
            }

        }
        public LevelModel QueryLevelById(long id)
        {
            try
            {
                return LevelModel.CurrentCacheList.Where(m => m.id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Config.log.Error("levelService.QueryLevelById", ex);
                return null;
            }
        }

        public ResultType DeleteLevelByIds(long[] ids)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    _levelRepository.Update(db, _levelRepository.DeleteEntity(), m => ids.Contains(m.id));
                }
                CacheHelper.RemoveCache(Config.levelCache);
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                Config.log.Error("levelService.DeleteLevelById", ex);
                return ResultType.SystemError;
            }
        }
    }
}
