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
using System.Transactions;

namespace HH.RMS.Service
{
    public class PersonService:ServiceBase,IPersonService
    {
        private IRepository<PersonEntity> _personRepository;
        private IRepository<CountryEntity> _countryRepository;
        private IRepository<ProvinceEntity> _provinceRepository;
        private IRepository<CityEntity> _cityRepository;
        private IRepository<AccountEntity> _accountRepository;
        private IRepository<AccountRoleEntity> _accountRoleRepository;
        public PersonService(IRepository<AccountRoleEntity> accountRoleRepository, IRepository<AccountEntity> accountRepository, IRepository<PersonEntity> personRepository, IRepository<CountryEntity> countryRepository, IRepository<ProvinceEntity> provinceRepository, IRepository<CityEntity> cityRepository)
        {
            _accountRoleRepository = accountRoleRepository;
            _accountRepository = accountRepository;
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

        public ResultModel<ResultType> CreatePersonAccount(AccountModel model)
        {
            using (var db = new ApplicationDbContext())
            {
                try
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        PersonEntity person = new PersonEntity()
                        {
                            name = model.person.name,
                            nickName = model.person.nickName,
                            address = model.person.address,
                            birthday = model.person.birthday,
                            cityId = model.person.cityId,
                            countryId = model.person.countryId,
                            email = model.person.email,
                            mobile = model.person.mobile,
                            provinceId = model.person.provinceId,
                            remark = model.person.remark,
                            sex = model.person.sex,
                        };
                        _personRepository.Insert(db, person);
                        if (person.id < 1)
                        {
                            return new ResultModel<ResultType>(ResultType.NotExecute,  "Person Insert Fail");
                        }
                        AccountEntity account = new AccountEntity()
                        {
                            personId = person.id,
                            accountName = model.accountName,
                            amount = model.amount,
                            level = model.level,
                            password = model.password,
                            remark = model.remark,
                            score = model.score,
                            status = model.statusType,
                        };
                        _accountRepository.Insert(db, account);
                        if (person.id < 1)
                        {
                            return new ResultModel<ResultType>(ResultType.NotExecute, "Account Insert Fail");
                        }
                        foreach (var role in model.roles)
                        {
                            AccountRoleEntity accountRole = new AccountRoleEntity()
                            {
                                accountId = account.id,
                                roleId = role
                            };
                            _accountRoleRepository.Insert(db, accountRole);
                        }
                        if (person.id < 1)
                        {
                            return new ResultModel<ResultType>(ResultType.NotExecute, "Account Role Insert Fail");
                        }
                        transaction.Complete();
                    }
                }
                catch (Exception ex)
                {
                    log.Error("PersonService.CreatePersonAccount", ex);
                    return new ResultModel<ResultType>(ResultType.SystemError);
                }
            }
            return new ResultModel<ResultType>(ResultType.Success);
        }
    }
}
