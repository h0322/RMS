
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
using HH.RMS.Service.Model;


namespace HH.RMS.Service.Web
{
    
    public class AccountService :  IAccountService
    {
        //private IRepository<AccountEntity> _accountRepository;
        private IRepository<AccountEntity> _accountRepository;
        private IRepository<RoleEntity> _roleRepository;
        private IRepository<LevelEntity> _levelRepository;
        private IRepository<PersonEntity> _personRepository;
        public AccountService(IRepository<LevelEntity> levelRepository,IRepository<RoleEntity> roleRepository, IRepository<AccountEntity> accountRepository, IRepository<PersonEntity> personRepository)
        {
            _roleRepository = roleRepository;
            _accountRepository = accountRepository;
            _personRepository = personRepository;
            _levelRepository = levelRepository;
            if (AccountModel.CurrentSession != null)
            {
                _roleRepository.userId = AccountModel.CurrentSession.id;
                _accountRepository.userId = AccountModel.CurrentSession.id;
                _personRepository.userId = AccountModel.CurrentSession.id;
                _levelRepository.userId = AccountModel.CurrentSession.id;
            }
        }


        public AccountModel QueryAccountById(long id)
        {
            try
            {
                AccountModel model = new AccountModel();
                using (var db = new ApplicationDbContext())
                {
                    var q = from a in _accountRepository.Query(db)
                            join b in _levelRepository.Query(db) on a.levelId equals b.id into t1
                            from tt1 in t1.DefaultIfEmpty()
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
                                personId = a.personId,
                                levelId = a.levelId,
                                roleBitMap = a.roleBitMap,
                                levelName = tt1 == null ? "" : tt1.levelName,
                                levelOrder = tt1 == null ? 0 : tt1.levelOrder
                            };
                    return q.FirstOrDefault();

                    //var account = _accountRepository.Query(db).Where(m => m.id == 2).FirstOrDefault();
                    //model.levelId = account.levelId;
                    //model.accountName = account.accountName;
                    //if (model.levelId > 0)
                    //{
                    //    var level = _levelRepository.Query(db).Where(m => m.id == model.levelId).FirstOrDefault();
                    //    model.levelName = level.levelName;
                    //    model.levelOrder = level.levelOrder;
                    //}
                    //return model;
                    //string sql = "select * from account A left join accountLevel B on A.levelId = B.id  where A.id=2";
                    //var accountEntity = _accountRepository.SqlQuery(db, sql, null).FirstOrDefault();
                    //return AccountModel.ModelMapper<AccountModel>(accountEntity);

                    //string sql = "select * from account A left join accountLevel B on A.levelId = B.id  where A.id=2";
                    //AccountModel model = new AccountModel();
                    //using (SqlConnection conn = new SqlConnection(Config.sqlConnStr))
                    //{
                    //    conn.Open();
                    //    SqlCommand comm = new SqlCommand(sql, conn);
                    //    SqlDataReader sdr = comm.ExecuteReader();
                    //    while (sdr.Read())
                    //    {
                    //        model.accountName = sdr["accountName"].ToString();
                    //        model.email = sdr["email"].ToString();
                    //        model.score = Convert.ToDecimal(sdr["score"]);
                    //        model.amount = Convert.ToDecimal(sdr["amount"]);
                    //        model.personId = Convert.ToInt64(sdr["personId"]);
                    //        model.levelId = Convert.ToInt64(sdr["levelId"]);
                    //        model.roleBitMap = Convert.ToInt64(sdr["roleBitMap"]);
                    //        model.levelName = sdr["levelName"].ToString();
                    //        model.levelOrder = Convert.ToInt32(sdr["levelOrder"]);
                    //    }
                    //    return model;
                    //}
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("AccountService.QueryPersonById;Id:"+id, ex);
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
                    if (result > 0)
                    {
                        return ResultType.Success;
                    }
                    else
                    {
                        Config.log.Info("AccountService.InsertAccount:Fail;accountName:"+model.accountName);
                        return ResultType.Fail;
                    }
                }


                
            }
            catch (Exception ex)
            {
                Config.log.Error("AccountService.InsertAccount", ex);
                return ResultType.SystemError;
            }
        }


        public GridModel QueryAccountToGridByRole(PagerModel pager)
        {
            if (pager == null)
            {
                pager = new PagerModel();
            }
            int roleOrder = (int)AccountModel.CurrentSession.accountType;
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = (from a in _accountRepository.Query(db)
                            join b in _personRepository.Query(db) on a.personId equals b.id
                            join c in _levelRepository.Query(db) on a.levelId equals c.id into t1
                            from tt1 in t1.DefaultIfEmpty()
                            where  (string.IsNullOrEmpty(pager.searchText) || a.accountName.Contains(pager.searchText))
                            && (int)a.accountType >= (int)AccountModel.CurrentSession.accountType
                            && (pager.searchStatus == 0 || a.status == (AccountStatusType)pager.searchStatus)
                            && (pager.searchDateFrom == null || a.createTime > pager.searchDateFrom)
                            && (pager.searchDateTo == null || a.createTime < pager.searchDateTo)
                            && (pager.searchRole == 0 || (a.roleBitMap & pager.searchRole) == pager.searchRole)
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
                                levelName = tt1 == null ? "" : tt1.levelName,
                                levelOrder = tt1 == null ? 0 : tt1.levelOrder
                            });
                    IQueryable<AccountModel> qPager = null;
                    if (pager.rows>0 && pager.page>0)
                    {
                        qPager = q.OrderByDescending(m => m.id).Take(pager.rows * pager.page).Skip(pager.rows * (pager.page - 1));
                        GridModel list = new GridModel()
                        {
                            rows = qPager.ToList(),
                            total = q.Count()
                        };
                        return list;
                    }
                    return new GridModel() { rows = q.ToList(), total = q.Count()};
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("AccountService.QueryAccountByRole", ex);
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
                        roleBitMap = model.roleBitMap,
                        updateBy = AccountModel.CurrentSession.id,
                        updateTime = DateTime.Now
                    }, m => m.id == model.id);
                    if (result > 0)
                    {
                        return ResultType.Success;
                    }
                    return ResultType.Fail;
                    //if (result > 0)
                    //{
                    //    result = _accountRoleRepository.Update(db, m => new AccountRoleEntity()
                    //    {
                    //        roleId = model.roleId,
                    //        updateBy = AccountModel.CurrentSession.id,
                    //        updateTime = DateTime.Now
                    //    }, m => m.accountId == model.id);
                    //    if (result > 0)
                    //    {
                    //        return ResultType.Success;
                    //    }
                    //    var accountRoleEntity = new AccountRoleEntity() { accountId = model.id, roleId = model.roleId };
                    //    result = _accountRoleRepository.Insert(db, accountRoleEntity);
                    //    if(result>0)
                    //    {
                    //        return ResultType.Success;
                    //    }
                    //    return ResultType.Fail;
                    //}
                    //else
                    //{
                    //    return ResultType.Fail;
                    //}
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("AccountService.UpdateAccount", ex);
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
                Config.log.Error("AccountService.DeleteAccountMassById", ex);
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
                Config.log.Error("AccountService.CountAccount", ex);
                return 0;
            }
 
        }

    }
}
