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
    }
}
