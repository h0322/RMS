
using HH.RMS.Common.Constant;
using HH.RMS.Entity.Web;
using HH.RMS.Service.Web.Model;
using HH.RMS.MVC.Models;
using HH.RMS.Repository.ADONet;
using HH.RMS.Repository.ADONet.Interface;
using HH.RMS.Repository.EntityFramework;
using HH.RMS.Repository.EntityFramework.Interface;
using HH.RMS.Service.Web.Interface;
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
using Nelibur.ObjectMapper;


namespace HH.RMS.Service.Web
{
    
    public class AccountService : ServiceBase, IAccountService
    {
        //private IRepository<AccountEntity> _accountRepository;
        private IRepository<AccountEntity> _accountRepository;
        private IRepository<RoleEntity> _roleRepository;
        private IRepository<AccountRoleEntity> _accountRoleRepository;
        private IRepository<LevelEntity> _levelRepository;
        private IRepository<PersonEntity> _personRepository;
        public AccountService(IRepository<LevelEntity> levelRepository,IRepository<RoleEntity> roleRepository, IRepository<AccountRoleEntity> accountRoleRepository, IRepository<AccountEntity> accountRepository, IRepository<PersonEntity> personRepository)
        {
            _roleRepository = roleRepository;
            _accountRoleRepository = accountRoleRepository;
            _accountRepository = accountRepository;
            _personRepository = personRepository;
            _levelRepository = levelRepository;
            if (AccountModel.CurrentSession != null)
            {
                _roleRepository.userId = AccountModel.CurrentSession.id;
                _accountRoleRepository.userId = AccountModel.CurrentSession.id;
                _accountRepository.userId = AccountModel.CurrentSession.id;
                _personRepository.userId = AccountModel.CurrentSession.id;
                _levelRepository.userId = AccountModel.CurrentSession.id;
            }
        }
        public AccountModel QueryAccountById(long id)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = from a in _accountRepository.Query(db)
                            join b in _accountRoleRepository.Query(db) on a.id equals b.accountId into t1
                            from tt1 in t1.DefaultIfEmpty()
                            join c in _levelRepository.Query(db) on a.levelId equals c.id into t2
                            from tt2 in t2.DefaultIfEmpty()
                            where a.id == id
                            select new AccountModel
                            {
                                id = a.id,
                                accountName = a.accountName,
                                email = a.email,
                                score = a.score,
                                amount = a.amount,
                                status = a.status,
                                remark = a.remark,
                                personId =  a.personId,
                                levelId = a.levelId,
                                roleId = tt1 == null ? 0 : tt1.roleId,
                                levelName = tt2 == null ? "" : tt2.levelName, 
                                levelOrder = tt2 == null ? 0 : tt2.levelOrder
                            };
                    return q.FirstOrDefault();
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
                var account = AccountModel.EntityMapper<AccountEntity>(model);
                using (var db = new ApplicationDbContext())
                {
                    int result = _accountRepository.Insert(db, account);
                    if(result>0)
                    {
                        var accountRoleEntity = new AccountRoleEntity() { accountId = account.id, roleId = model.roleId };
                        result = _accountRoleRepository.Insert(db, accountRoleEntity);
                        if (result > 0)
                        {
                            return ResultType.Success;
                        }
                        else
                        {
                            return ResultType.Fail;
                        }
                    }
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
            int roleOrder = AccountModel.CurrentSession.roleOrder;
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = (from a in _accountRepository.Query(db)
                            join b in _personRepository.Query(db) on a.personId equals b.id
                            join c in _accountRoleRepository.Query(db) on a.id equals c.accountId into t1
                            from tt1 in t1.DefaultIfEmpty() 
                            join d in _levelRepository.Query(db) on a.levelId equals d.id into t2
                            from tt2 in t2.DefaultIfEmpty()
                            where  (string.IsNullOrEmpty(pager.searchText) || a.accountName.Contains(pager.searchText))
                            && (pager.searchStatus == 0 || a.status == (AccountStatusType)pager.searchStatus)
                            && (pager.searchDateFrom == null || a.createTime > pager.searchDateFrom)
                            && (pager.searchDateTo == null || a.createTime < pager.searchDateTo)
                            && (pager.searchRole == 0 || tt1.roleId == pager.searchRole)
                            && (pager.personId == 0 || a.personId == pager.personId)
                            select new AccountModel()
                            {
                                id = a.id,
                                accountName = a.accountName,
                                email = a.email,
                                status = a.status,
                                score = a.score,
                                amount = a.amount,
                                createTime = a.createTime,
                                personId = b.id, 
                                birthday = b.birthday, 
                                cityId = b.cityId, 
                                countryId = b.countryId, 
                                name = b.name, 
                                nickName = b.nickName, 
                                provinceId = b.provinceId, 
                                sex = b.sex,
                                levelId = a.id,
                                levelName = tt1 == null ? "" : tt2.levelName,
                                levelOrder = tt2 == null ? 0 : tt2.levelOrder
                            });
                    IQueryable<AccountModel> qPager = null;
                    if (pager != null)
                    {
                        qPager = q.OrderByDescending(m => m.id).Take(pager.rows * pager.page).Skip(pager.rows * (pager.page - 1));
                    }
                    GridModel list = new GridModel()
                    {
                        rows = qPager.ToList(),
                        total = q.Count()
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
        public ResultType UpdateAccount(AccountModel model)
        {
            try
            {
                var entity = AccountModel.EntityMapper<AccountEntity>(model);
                
                using (var db = new ApplicationDbContext())
                {
                    int result = _accountRepository.Update(db, m => new AccountEntity()
                    {
                        amount = model.amount,
                        score = model.score,
                        levelId = model.levelId,
                        status = model.status,
                        updateBy = AccountModel.CurrentSession.id,
                        updateTime = DateTime.Now
                    }, m => m.id == model.id);
                    if (result > 0)
                    {
                        result = _accountRoleRepository.Update(db, m => new AccountRoleEntity()
                        {
                            roleId = model.roleId,
                            updateBy = AccountModel.CurrentSession.id,
                            updateTime = DateTime.Now
                        }, m => m.accountId == model.id);
                        if (result > 0)
                        {
                            return ResultType.Success;
                        }
                        var accountRoleEntity = new AccountRoleEntity() { accountId = model.id, roleId = model.roleId };
                        result = _accountRoleRepository.Insert(db, accountRoleEntity);
                        if(result>0)
                        {
                            return ResultType.Success;
                        }
                        return ResultType.Fail;
                    }
                    else
                    {
                        return ResultType.Fail;
                    }
                }
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
        public ResultType DeleteAccountMassById(long[] ids)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    _accountRepository.Update(db, _accountRepository.DeleteEntity(), m => ids.Contains(m.id));
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
