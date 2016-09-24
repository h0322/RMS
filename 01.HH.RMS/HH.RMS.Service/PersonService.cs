using HH.RMS.Common.Constant;
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
        public PersonModel QueryPersonById(long id)
        {
            PersonModel model = new PersonModel();
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var entity = _personRepository.Find(db, id);
                    if (entity != null)
                    {
                        model.personId = entity.id;
                        model.address = entity.address;
                        model.birthday = entity.birthday;
                        model.cityId = entity.cityId;
                        model.countryId = entity.countryId;
                        model.provinceId = entity.provinceId;
                        model.remark = entity.remark;
                        model.sex = entity.sex;
                        model.email = entity.email;
                        model.mobile = entity.mobile;
                        model.name = entity.name;
                        model.nickName = entity.nickName;
                    }
                }
                return model;
            }
            catch (Exception ex)
            {
                log.Error("PersonService.QueryPersonById", ex);
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
                            levelId = model.level.levelId,
                            password = model.password,
                            remark = model.remark,
                            score = model.score,
                            status = model.statusType,
                        };
                        _accountRepository.Insert(db, account);
                        if (account.id < 1)
                        {
                            return new ResultModel<ResultType>(ResultType.NotExecute, "Account Insert Fail");
                        }
                        AccountRoleEntity accountRole = new AccountRoleEntity()
                        {
                            accountId = account.id,
                            roleId = model.role.roleId
                        };
                        _accountRoleRepository.Insert(db, accountRole);
                        if (accountRole.id < 1)
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

        public ResultType UpdatePersonById(PersonModel model)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    _personRepository.Update(db, m => new PersonEntity()
                    {
                        cityId = model.cityId,
                        address = model.address,
                        birthday = model.birthday,
                        countryId = model.countryId,
                        email = model.email,
                        mobile = model.mobile,
                        name = model.name,
                        nickName = model.nickName,
                        provinceId = model.provinceId,
                        remark = model.remark,
                        sex = model.sex,
                        updateTime = DateTime.Now,
                        updateBy = AccountModel.Session.accountId
                    },
                    m => m.id == model.personId
                    );
                }
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                log.Error("PersonService.UpdatePerson", ex);
                return ResultType.SystemError;
            }
        }
    }
}
