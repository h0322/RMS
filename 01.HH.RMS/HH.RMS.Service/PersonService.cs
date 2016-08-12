using HH.RMS.Common.Constant;
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
    public class PersonService:ServiceBase,IPersonService
    {
        private IRepository<PersonEntity> _personRepository;
        private IRepository<CountryEntity> _countryRepository;
        private IRepository<ProvinceEntity> _provinceRepository;
        private IRepository<CityEntity> _cityRepository;
        public PersonService(IRepository<PersonEntity> personRepository, IRepository<CountryEntity> countryRepository, IRepository<ProvinceEntity> provinceRepository, IRepository<CityEntity> cityRepository)
        {
            _personRepository = personRepository;
            _countryRepository = countryRepository;
            _provinceRepository = provinceRepository;
            _cityRepository = cityRepository;
        }
        public GridModel QueryPersonToGrid(PagerModel pager)
        {
            try{
                using (var db = new ApplicationDbContext())
                {
                    var q = (from a in _personRepository.Query(db)
                             join b in _countryRepository.Query(db) on a.countryId equals b.id
                             join c in _provinceRepository.Query(db) on a.provinceId equals c.id
                             join d in _cityRepository.Query(db) on a.cityId equals d.id
                             where (string.IsNullOrEmpty(pager.searchText) || a.name.Contains(pager.searchText) || a.mobile.Contains(pager.searchText) || a.email.Contains(pager.searchText))
                                && (pager.searchDateFrom == null || a.createTime > pager.searchDateFrom)
                                && (pager.searchDateTo == null || a.createTime < pager.searchDateTo)
                             select new PersonModel
                             {
                                personId = a.id,
                                birthday = a.birthday,
                                mobile = a.mobile,
                                email = a.email,
                                cityId = a.cityId,
                                cityName = d.name,
                                countryId = a.countryId,
                                countryDescription = b.name,
                                name = a.name,
                                nickName = a.nickName,
                                provinceId = a.provinceId,
                                provinceName = c.name,
                                remark = a.remark,
                                createTime = a.createTime,
                                sex = a.sex
                             });
                    IQueryable<PersonModel> qPager = null;
                    if (pager != null)
                    {
                        qPager = q.OrderByDescending(m => m.personId).Take(pager.rows * pager.page).Skip(pager.rows * (pager.page - 1));
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
                log.Error("PersonService.QueryPersonList", ex);
                return null;
            }
        }
        public PersonEntity QueryPersonById(long id)
        {

            //return _personRepository.Query().Where(m=>m.id==id).FirstOrDefault();
            return null;
        }
    }
}
