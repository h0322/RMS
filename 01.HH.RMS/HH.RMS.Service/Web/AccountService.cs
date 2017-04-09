
using HH.RMS.Common.Constant;
using HH.RMS.Entity.Web;
using HH.RMS.IService.Web.Model;
using HH.RMS.MVC.Models;
using HH.RMS.Repository;
using HH.RMS.Repository.Interface;
using HH.RMS.IService.Web;
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
    
    public class AccountService :  IAccountService
    {
        //private IRepository<AccountEntity> _accountRepository;
        private IRepository<AccountEntity> _accountRepository;
        private IRepository<RoleEntity> _roleRepository;
        private IRepository<LevelEntity> _levelRepository;
        private IRepository<ResetPasswordLogEntity> _resetPasswordLogRepository;
        public AccountService(IRepository<ResetPasswordLogEntity> resetPasswordLogRepository,IRepository<LevelEntity> levelRepository,IRepository<RoleEntity> roleRepository, IRepository<AccountEntity> accountRepository)
        {
            _roleRepository = roleRepository;
            _accountRepository = accountRepository;
            _levelRepository = levelRepository;
            _resetPasswordLogRepository = resetPasswordLogRepository;
        }

        public AccountModel QueryAccountById(long id)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var entity = _accountRepository.Query(db).Where(m => m.id == id).FirstOrDefault();
                    if (entity == null)
                    {
                        return null;
                    }
                    AccountModel model = new AccountModel()
                    {
                        id = entity.id,
                        birthday = entity.birthday,
                        levelId = entity.levelId,
                        accountName = entity.accountName,
                        email = entity.email,
                        amount = entity.amount,
                        status = entity.status,
                        remark = entity.remark,
                        accountType = entity.accountType,
                        roleBitMap = entity.roleBitMap,
                        countryId = entity.countryId,
                        provinceId = entity.provinceId,
                        cityId = entity.cityId,
                        createBy = entity.createBy,
                        createTime = entity.createTime,
                        name = entity.name,
                        nickName = entity.nickName,
                        password = entity.password,
                        passwordType = entity.passwordType,
                        score = entity.score,
                        sex = entity.sex
                    };
                    return model;
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
        public ResultType UpdateAccountById(AccountModel model)
        {
            try
            {
                var entity = AccountModel.EntityMapper<AccountEntity>(model);
                
                using (var db = new ApplicationDbContext())
                {
                    int result = _accountRepository.Update(db, m => new AccountEntity()
                    {
                        accountType = model.accountType,
                        address = model.address,
                        birthday = model.birthday,
                        cityId = model.cityId,
                        countryId = model.countryId,
                        email = model.email,
                        mobile = model.mobile,
                        name = model.name,
                        parentAccountId = model.parentAccountId,
                        passwordType = model.passwordType,
                        nickName = model.nickName,
                        sex = model.sex,
                        provinceId = model.provinceId,
                        remark = model.remark,
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
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    _accountRepository.Update(db, m => new AccountEntity()
                    {
                        updateBy = AccountModel.CurrentSession.id,
                        updateTime = DateTime.Now,
                        isActive = false
                    }, m => m.id == id);
                }
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                Config.log.Error("AccountService.DeleteAccountMassById", ex);
                return ResultType.SystemError;
            }
        }
        public ResultType DeleteAccountMassById(long[] ids)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    _accountRepository.Update(db, m => new AccountEntity() {
                        updateBy = AccountModel.CurrentSession.id,
                        updateTime = DateTime.Now,
                        isActive = false 
                    }, m => ids.Contains(m.id));
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
        public ResultType ResetPassword(ResetPasswordModel model)
        {
            var entity = ResetPasswordModel.EntityMapper<ResetPasswordLogEntity>(model);
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var logList = _resetPasswordLogRepository.Query(db).Where(m => m.accountId == model.accountId).OrderByDescending(m => m.id).ToList();
                    if (model.times > logList.Count)
                    {
                        model.times = logList.Count;
                    }
                    for (int i = 0; i < model.times; i++)
                    {
                        if (logList[i].password == model.password)
                        {
                            return ResultType.IsExists;
                        }
                    }
                    int result = _accountRepository.Update(db,
                        m => new AccountEntity() { password = model.password },
                        m => m.id == model.accountId);
                    if (result < 1)
                    {
                        return ResultType.Fail;
                    }
                    result = _resetPasswordLogRepository.Insert(db, entity);
                    if (result < 1)
                    {
                        return ResultType.Fail;
                    }

                    return ResultType.Success;
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("LoginService.ForgetPassword", ex);
                return ResultType.SystemError;
            }
        }
    }
}
