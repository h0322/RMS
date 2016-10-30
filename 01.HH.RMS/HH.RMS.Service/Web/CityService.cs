using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity.Web;
using HH.RMS.Service.Web.Model;
using HH.RMS.Repository.EntityFramework;
using HH.RMS.Repository.EntityFramework.Interface;
using HH.RMS.Service.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nelibur.ObjectMapper;

namespace HH.RMS.Service.Web
{
    public class CityService : ServiceBase, ICityService
    {
        private IRepository<CityEntity> _cityRepository;
        public CityService(IRepository<CityEntity> cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public List<CityModel> QueryCityListAll()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var list = _cityRepository.Query(db).ToList();
                    return TinyMapper.Map<List<CityModel>>(list);
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
