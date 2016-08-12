using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
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
    public class ProvinceService : ServiceBase, IProvinceService
    {
        private IRepository<ProvinceEntity> _provinceRepository;
        public ProvinceService(IRepository<ProvinceEntity> provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }
        public List<ProvinceModel> QueryProvinceList()
        {
            try
            { 
                if (CacheHelper.GetCache(Config.provinceCache) == null)
                {
                    using (var db = new ApplicationDbContext())
                    {
                        var q = from a in _provinceRepository.Query(db)
                                select new ProvinceModel()
                                {
                                    name = a.name,
                                    provinceId = a.id,
                                    order = a.order
                                };
                        CacheHelper.SetCache(Config.provinceCache, q.ToList());
                    }
                }
                List<ProvinceModel> provinceList = (List<ProvinceModel>)CacheHelper.GetCache(Config.provinceCache);
                return provinceList;
            }
            catch (Exception ex)
            {
                log.Error("ProvinceService.QueryProvinceList", ex);
                return null;
            }
        }
    }
}
