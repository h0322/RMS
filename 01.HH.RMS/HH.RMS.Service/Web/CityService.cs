using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity;
using HH.RMS.Service.Web.Model;
using HH.RMS.Repository.EntityFramework;
using HH.RMS.Repository.EntityFramework.Interface;
using HH.RMS.Service.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web
{
    public class CityService : ServiceBase, ICityService
    {
        private IRepository<CityEntity> _cityRepository;
        public CityService(IRepository<CityEntity> cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public List<CityModel> QueryCityListByProvinceId(long provinceId)
        {
            try
            { 
                List<CityModel> cityList = CityModel.ListCache;
                return cityList.Where(m => m.provinceId == provinceId).ToList();
            }
            catch (Exception ex)
            {
                log.Error("CityService.QueryCityListByProvinceId", ex);
                return null;
            }
        }
        public List<CityModel> QueryCityListAll()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = from a in _cityRepository.Query(db)
                            select new CityModel()
                            {
                                name = a.name,
                                provinceId = a.provinceId,
                                cityId = a.id,
                                order = a.order
                            };
                    return q.ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("CityService.QueryCityListAll", ex);
                return null;
            }
        }
    }
}
