using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity.Web;
using HH.RMS.IService.Web.Model;
using HH.RMS.Repository;
using HH.RMS.Repository.Interface;
using HH.RMS.IService.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nelibur.ObjectMapper;

namespace HH.RMS.Service.Web
{
    public class CountryService :  ICountryService
    {
        private IRepository<CountryEntity> _countryRepository;
        public CountryService(IRepository<CountryEntity> countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public List<CountryModel> QueryCountryList()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var list = TinyMapper.Map<List<CountryModel>>(_countryRepository.Query(db).ToList());
                    return list;
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("CountryService.QueryCountryList", ex);
                return null;
            }
        }
        public ResultType InsertCountry(CountryModel model)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var entity = TinyMapper.Map<CountryEntity>(model);
                    _countryRepository.Insert(db, entity);
                }
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                Config.log.Error("CountryService.InsertCountry", ex);
                return ResultType.SystemError;
            }
        }
        public ResultType UpdateCountry(CountryModel model)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    _countryRepository.Update(db, m => new CountryEntity()
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
