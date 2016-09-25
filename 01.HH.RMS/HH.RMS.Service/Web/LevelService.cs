using HH.RMS.Common.Constant;
using HH.RMS.Entity;
using HH.RMS.Repository.EntityFramework;
using HH.RMS.Repository.EntityFramework.Interface;
using HH.RMS.Service.Web.Interface;
using HH.RMS.Service.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web
{
    public class LevelService : ServiceBase, ILevelService
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
                using (var db = new ApplicationDbContext())
                {
                    var q = (from a in _levelRepository.Query(db)
                             where (string.IsNullOrEmpty(pager.searchText) || a.levelName.Contains(pager.searchText))
                                && (pager.searchDateFrom == null || a.createTime > pager.searchDateFrom)
                                && (pager.searchDateTo == null || a.createTime < pager.searchDateTo)
                             select new LevelModel
                             {
                                levelName = a.levelName,
                                levelOrder = a.levelOrder,
                                levelId= a.id
                             });
                    IQueryable<LevelModel> qPager = null;
                    if (pager != null)
                    {
                        qPager = q.OrderByDescending(m => m.levelId).Take(pager.rows * pager.page).Skip(pager.rows * (pager.page - 1));
                    }
                    GridModel gridModel = new GridModel()
                    {
                        rows = qPager.ToList(),
                        total = q.Count()
                    };
                    return gridModel;
                    //return null;
                }
            }
            catch (Exception ex)
            {
                log.Error("LevelService.QueryLevelToGrid", ex);
                return null;
            }
        }
        public List<LevelModel> QueryLevelList()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = from a in _levelRepository.Query(db)
                            select new LevelModel()
                            {
                                levelId = a.id,
                                levelName = a.levelName,
                                levelOrder = a.levelOrder
                            };
                    return q.ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("LevelService.QueryLevelList", ex);
                return null;
            }
        }
        public ResultType CreateLevel(LevelModel model)
        {
            try {
                using (var db = new ApplicationDbContext())
                {
                    _levelRepository.Insert(db, new LevelEntity()
                    {
                        levelName = model.levelName,
                        levelOrder = model.levelOrder
                    });
                    return ResultType.Success;
                }
            }
            catch (Exception ex)
            {
                log.Error("LevelService.InserLevel", ex);
                return ResultType.SystemError;
            }
 
        }

        public ResultType UpdateLevel(LevelModel model)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    _levelRepository.Update(db, m => new LevelEntity()
                    {
                        levelName = model.levelName,
                        levelOrder = model.levelOrder,
                        updateTime = DateTime.Now,
                        updateBy = AccountModel.Session.accountId
                    },
                    m => m.id == model.levelId
                    );
                }
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                log.Error("LevelService.UpdateLevel", ex);
                return ResultType.SystemError;
            }

        }
        public LevelModel QueryLevelById(long id)
        {
            try
            {
                return LevelModel.ListCache.Where(m => m.levelId == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                log.Error("levelService.QueryLevelById", ex);
                return null;
            }
        }
    }
}
