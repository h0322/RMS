using HH.RMS.Common.Constant;
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
using System.Transactions;
using HH.RMS.Service.Model;
using Nelibur.ObjectMapper;

namespace HH.RMS.Service.Web
{
    public class PersonService:IPersonService
    {
        private IRepository<PersonEntity> _personRepository;
        private IRepository<CountryEntity> _countryRepository;
        private IRepository<ProvinceEntity> _provinceRepository;
        private IRepository<CityEntity> _cityRepository;
        private IRepository<AccountEntity> _accountRepository;
        public PersonService(IRepository<AccountEntity> accountRepository, IRepository<PersonEntity> personRepository, IRepository<CountryEntity> countryRepository, IRepository<ProvinceEntity> provinceRepository, IRepository<CityEntity> cityRepository)
        {
            _accountRepository = accountRepository;
            _personRepository = personRepository;
            _countryRepository = countryRepository;
            _provinceRepository = provinceRepository;
            _cityRepository = cityRepository;
        }
        public GridModel QueryPersonToGrid(PagerModel pager=null)
        {
            if (pager == null)
            {
                pager = new PagerModel();
            }
            try{
                using (var db = new ApplicationDbContext())
                {
                    var q = (from a in _personRepository.Query(db)
                             join b in _countryRepository.Query(db) on a.countryId equals b.id into t1
                             from tt1 in t1.DefaultIfEmpty()
                             join c in _provinceRepository.Query(db) on a.provinceId equals c.id into t2
                             from tt2 in t2.DefaultIfEmpty()
                             join d in _cityRepository.Query(db) on a.cityId equals d.id into t3
                             from tt3 in t3.DefaultIfEmpty()
                             where (string.IsNullOrEmpty(pager.searchText) || a.name.Contains(pager.searchText) || a.mobile.Contains(pager.searchText))
                                && (pager.searchDateFrom == null || a.createTime > pager.searchDateFrom)
                                && (pager.searchDateTo == null || a.createTime < pager.searchDateTo)
                             select new PersonModel
                             {
                                id = a.id,
                                birthday = a.birthday,
                                mobile = a.mobile,
                                name = a.name,
                                nickName = a.nickName,
                                remark = a.remark,
                                createTime = a.createTime,
                                sex = a.sex,
                                countryId = tt1==null?0:tt1.id,
                                countryName = tt1 == null ? "" : tt1.name,
                                provinceId = tt2 == null ? 0 : tt2.id,
                                provinceName = tt2 == null ? "" : tt2.name,
                                cityId = tt3 == null ? 0 : tt3.id,
                                cityName = tt3 == null ? "" : tt3.name,
                             });
                    if (pager.rows>0 && pager.page>0)
                    {
                            q = q.OrderByDescending(m => m.id).Take(pager.rows * pager.page).Skip(pager.rows * (pager.page - 1));
                    }
                    GridModel gridModel = new GridModel()
                    {
                        rows = q.ToList(),
                        total = q.Count()
                    };
                    return gridModel;
                    
                    //return null;
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("PersonService.QueryPersonToGrid", ex);
                return null;
            }
        }
        public PersonModel QueryPersonById(long id)
        {
            PersonModel model = new PersonModel();
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var entity = _personRepository.Find(db, id);
                    return TinyMapper.Map<PersonModel>(entity);
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("PersonService.QueryPersonById", ex);
            }
            return null;
        }

        public ResultModel<ResultType> CreatePersonAccount(AccountModel model)
        {
            using (var db = new ApplicationDbContext())
            {
                try
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        var person = TinyMapper.Map<PersonEntity>(model);
                        _personRepository.Insert(db, person);
                        if (person.id < 1)
                        {
                            return new ResultModel<ResultType>(ResultType.NotExecute, "Person Insert Fail");
                        }
                        AccountEntity account = TinyMapper.Map<AccountEntity>(model);
                        account.personId = person.id;
                        _accountRepository.Insert(db, account);
                        if (account.id < 1)
                        {
                            return new ResultModel<ResultType>(ResultType.NotExecute, "Account Insert Fail");
                        }
                        transaction.Complete();
                    }
                }
                catch (Exception ex)
                {
                    Config.log.Error("PersonService.CreatePersonAccount", ex);
                    return new ResultModel<ResultType>(ResultType.SystemError);
                }
            }
            return new ResultModel<ResultType>(ResultType.Success);
        }

        public ResultType UpdatePersonById(PersonModel model)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    _personRepository.Update(db, m => new PersonEntity()
                    {
                        mobile = model.mobile,
                        address = model.address,
                        birthday = model.birthday,
                        cityId = model.cityId,
                        countryId=model.countryId,
                        name = model.name,
                        nickName = model.nickName,
                        sex = model.sex,
                        provinceId = model.provinceId,
                        remark = model.remark??"",
                        updateBy = AccountModel.CurrentSession.id,
                        updateTime = DateTime.Now
                    },
                    m=>m.id == model.id);
                }
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                Config.log.Error("PersonService.UpdatePerson", ex);
                return ResultType.SystemError;
            }
        }
    }
}
