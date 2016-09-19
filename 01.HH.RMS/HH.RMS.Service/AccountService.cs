
using HH.RMS.Common.Constant;
using HH.RMS.Entity;
using HH.RMS.Model;
using HH.RMS.MVC.Models;
using HH.RMS.Repository.ADONet;
using HH.RMS.Repository.ADONet.Interface;
using HH.RMS.Repository.EntityFramework;
using HH.RMS.Repository.EntityFramework.Interface;
using HH.RMS.Service.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq.Expressions;


namespace HH.RMS.Service
{
    public class AccountService : ServiceBase, IAccountService
    {
        //private IRepository<AccountEntity> _accountRepository;
        private IRepository<AccountEntity> _accountRepository;
        private IRepository<RoleEntity> _roleRepository;
        private IRepository<AccountRoleEntity> _accountRoleRepository;
        private IRepository<PersonEntity> _personRepository;
        public AccountService(IRepository<RoleEntity> roleRepository, IRepository<AccountRoleEntity> accountRoleRepository, IRepository<AccountEntity> accountRepository, IRepository<PersonEntity> personRepository)
        {
            _roleRepository = roleRepository;
            _accountRoleRepository = accountRoleRepository;
            _accountRepository = accountRepository;
            _personRepository = personRepository;
        }
        public AccountModel QueryAccountById(long id)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = from a in _accountRepository.Query(db)
                            join b in _accountRoleRepository.Query(db) on a.id equals b.accountId
                            join c in _roleRepository.Query(db) on b.roleId equals c.id
                            where a.id == id
                            select new
                            {
                                accountId = a.id,
                                accountName = a.accountName,
                                level = a.level,
                                score = a.score,
                                amount = a.amount,
                                statusType = a.status,
                                remark = a.remark,
                                person = new PersonModel() { personId = a.personId},
                                role = new RoleModel(){roleId = b.roleId, roleName = c.roleName}
                            };
                    var list = q.ToList();
                    List<long> roleList = new List<long>();
                    list.ForEach(m=>roleList.Add(m.role.roleId));
                    var def = list.FirstOrDefault();

                    AccountModel account = new AccountModel(){
                                accountId = def.accountId,
                                accountName = def.accountName,
                                level = def.level,
                                score = def.score,
                                amount = def.amount,
                                statusType = def.statusType,
                                remark = def.remark,
                                person = new PersonModel() { personId = def.person.personId},
                                roles =roleList.ToArray()
                    };
                    return account;
                }
            }
            catch (Exception ex)
            {
                log.Error("AccountService.QueryPersonById", ex);
                return null;
            }
        }
        public ResultType InsertAccount(AccountModel model)
        {
            try
            {
                AccountEntity account = new AccountEntity()
                {
                    accountName = model.accountName,
                    password = model.password,
                    level = model.level,
                    score = model.score,
                    amount = model.amount,
                    status = model.statusType,
                    remark = model.remark
                };

                using (var db = new ApplicationDbContext())
                {
                    _accountRepository.Insert(db, account);
                }

                return ResultType.Success;
            }
            catch (Exception ex)
            {
                log.Error("AccountService.InsertAccount", ex);
                return ResultType.SystemError;
            }
        }


        public GridModel QueryAccountToGridByRole(PagerModel pager = null)
        {
            int roleOrder = AccountDetailModel.loginSession.role.roleOrder;
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = (from a in _accountRepository.Query(db)
                            join b in _accountRoleRepository.Query(db) on a.id equals b.accountId
                            join c in _roleRepository.Query(db) on b.roleId equals c.id
                            join d in _personRepository.Query(db) on a.personId equals d.id
                            where c.roleOrder >= roleOrder
                            && (string.IsNullOrEmpty(pager.searchText) || a.accountName.Contains(pager.searchText))
                            && (pager.searchStatus == 0 || a.status == (AccountStatusType)pager.searchStatus)
                            && (pager.searchDateFrom == null || a.createTime > pager.searchDateFrom)
                            && (pager.searchDateTo == null || a.createTime < pager.searchDateTo)
                            && (pager.searchRole == 0 || b.roleId == pager.searchRole)
                            select new AccountModel()
                            {
                                accountId = a.id,
                                accountName = a.accountName,
                                statusType = a.status,
                                score = a.score,
                                amount = a.amount,
                                level = a.level,
                                createTime = a.createTime,
                                person = new PersonModel() { personId = d.id, birthday = d.birthday, cityId = d.cityId, countryId = d.countryId, createTime = d.createTime, name = d.name, nickName = d.nickName, provinceId = d.provinceId, sex = d.sex }
                            });
                    IQueryable<AccountModel> qPager = null;
                    if (pager != null)
                    {
                        qPager = q.OrderByDescending(m => m.accountId).Take(pager.rows * pager.page).Skip(pager.rows * (pager.page - 1));
                    }
                    GridModel list = new GridModel()
                    {
                        rows = qPager.ToList(),
                        total = q.Count()
                        //pageNumber = pager.pageNumber,
                        //pageSize = pager.pageSize
                    };
                    return list;
                }
            }
            catch (Exception ex)
            {
                log.Error("AccountService.QueryAccountByRole", ex);
                return null;
            }
        }

        public AccountListModel QueryAccountListByPersonId(long id)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = from a in _accountRepository.Query(db)
                            where a.personId == id
                            select new AccountModel()
                            {
                                accountId = a.id,
                                accountName = a.accountName,
                                statusType = a.status,
                                score = a.score,
                                amount = a.amount,
                                level = a.level,
                                createTime = a.createTime,
                            };
                    AccountListModel list = new AccountListModel()
                    {
                        accountList = q.ToList()
                    };
                    return list;
                }
            }
            catch (Exception ex)
            {
                log.Error("AccountService.QueryAccountListByPersonId", ex);
                return null;
            }
        }
        public ResultType UpdateAccount(AccountModel model)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    _accountRepository.Update(db, m => new AccountEntity()
                    {
                        level = model.level,
                        score = model.score,
                        amount = model.amount,
                        remark = model.remark,
                        status = model.statusType,
                        updateTime = DateTime.Now,
                        updateBy = AccountDetailModel.loginSession.account.accountId
                    },
                    m => m.id == model.accountId
                    );
                    _accountRoleRepository.Update(db, m => new AccountRoleEntity()
                    {
                        isActive = false
                    },
                    m=>m.accountId == model.accountId);
                    foreach (var role in model.roles)
                    {
                        AccountRoleEntity accountRole = new AccountRoleEntity()
                        {
                            accountId = model.accountId,
                            roleId = role
                        };
                        _accountRoleRepository.Insert(db, accountRole);
                    }
                }
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                log.Error("AccountService.UpdateAccount", ex);
                return ResultType.SystemError;
            }
        }

        public ResultType DeleteAccountById(long id)
        {
            return ResultType.Success;
        }
        public ResultType DeleteAccountMassById(List<string> idList)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    _accountRepository.Update(db, m => new AccountEntity()
                    {
                        isActive = false,
                        updateTime = DateTime.Now,
                        updateBy = AccountDetailModel.loginSession.account.accountId
                    },
                    m => idList.Contains(m.id.ToString())
                    );
                }
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                log.Error("AccountService.DeleteAccountMassById", ex);
                return ResultType.SystemError;
            }
        }

        public int CountAccount()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    return _accountRepository.Query(db).Count();
                }
            }
            catch (Exception ex)
            {
                log.Error("AccountService.CountAccount", ex);
                return 0;
            }
 
        }

    }
}
