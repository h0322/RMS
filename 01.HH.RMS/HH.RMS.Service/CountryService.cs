using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity;
using HH.RMS.Service.Model;
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
    public class CountryService : ServiceBase, ICountryService
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
                if (CacheHelper.GetCache(Config.countryCache) == null)
                {
                    using (var db = new ApplicationDbContext())
                    {
                        CacheHelper.SetCache(Config.countryCache, _countryRepository.Query(db).ToList());
                    }
                }
                List<CountryModel> countryList = (List<CountryModel>)CacheHelper.GetCache(Config.countryCache);
                return countryList;
            }
            catch (Exception ex)
            {
                log.Error("CountryService.QueryCountryList", ex);
                return null;
            }
        }
    }
}
