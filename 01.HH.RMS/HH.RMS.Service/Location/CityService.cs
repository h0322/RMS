using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity;
using HH.RMS.IService.Model;
using HH.RMS.Repository;
using HH.RMS.Repository.Interface;
using HH.RMS.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nelibur.ObjectMapper;
using HH.RMS.Entity.Location;
using HH.RMS.IService.Model.Location;
using HH.RMS.IService.Location;

namespace HH.RMS.Service.Location
{
    public class CityService :  ICityService
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
                Config.log.Error("CityService.QueryCityListAll", ex);
                return null;
            }
        }
        public ResultType InsertCountry(CityModel model)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var entity = TinyMapper.Map<CityEntity>(model);
                    _cityRepository.Insert(db, entity);
                }
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                Config.log.Error("CountryService.InsertCountry", ex);
                return ResultType.SystemError;
            }
        }
        public ResultType UpdateCountry(CityModel model)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    _cityRepository.Update(db, m => new CityEntity()
                    {
                        code = model.code,
                        name = model.name,
                        order = model.order,
                        remark = model.remark,
                        updateBy = AccountModel.CurrentSession.id,
                        updateTime = DateTime.Now
                    }, m => m.id == model.id);
                }
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                Config.log.Error("CountryService.UpdateCountry", ex);
                return ResultType.SystemError;
            }
        }
    }
}
