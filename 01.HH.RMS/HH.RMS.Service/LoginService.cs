﻿using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity;
using HH.RMS.IService.Model;
using HH.RMS.Repository;
using HH.RMS.Repository.Interface;
using HH.RMS.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using Nelibur.ObjectMapper;
using HH.RMS.Common.Model;

namespace HH.RMS.Service
{
    public class LoginService : ILoginService
    {
        private IRepository<AccountEntity> _accountRepository;
        private IRepository<RoleEntity> _roleRepository;
        private IRepository<LevelEntity> _levelRepository;
        private IRepository<ResetPasswordLogEntity> _resetPasswordLogRepository;
        private IEmailService _emailService;
        public LoginService(IEmailService emailService, IRepository<ResetPasswordLogEntity> resetPasswordLogRepository, IRepository<LevelEntity> levelRepository, IRepository<AccountEntity> accountRepository, IRepository<RoleEntity> roleRepository)
        {
            _emailService = emailService;
            _accountRepository = accountRepository;
            _roleRepository = roleRepository;
            _levelRepository = levelRepository;
            _resetPasswordLogRepository = resetPasswordLogRepository;
        }
        public ResultModel<AccountModel> UserLogin(string accountName, string password)
        {
            ResultModel<AccountModel> result = new ResultModel<AccountModel>();
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var entity = _accountRepository.Query(db).Where(m => m.accountName == accountName && m.password == password).FirstOrDefault();
                    var model = AccountModel.ModelMapper<AccountModel>(entity);
                    result.resultObj = model;
                }
                if (result.resultObj != null)
                {
                    result.resultType = ResultType.Success;
                    result.resultMsg = "Login Success";
                    return result;
                }
                result.resultType = ResultType.Fail;
                result.resultMsg = "Login Fail";
                return result;
            }
            catch (Exception ex)
            {
                Config.log.Error("LoginService.ResultModel", ex);
                result.resultType = ResultType.SystemError;
                result.resultMsg = "Login Fail";
            }
            return result;
        }
        public void ExitLogin()
        {
            SessionHelper.SessionClear();
            FormsAuthentication.SignOut();
            return;
        }
        public ResultModel<ResultType> ForgetPassword(AccountModel model)
        {
            int radNumber = new Random().Next(100000, 999999);
            EmailModel emailModel = _emailService.QueryEmailById(EmailHelper.forgetPasswordEmailId);
            if (emailModel == null)
            {
                return new ResultModel<ResultType>(ResultType.NotExists,"邮件内容不存在","");
            }

            try
            {
                using (var db = new ApplicationDbContext())
                {
                    AccountEntity entity = null;
                    if (!string.IsNullOrEmpty(model.accountName))
                    {
                        entity = _accountRepository.Query(db).Where(m => m.accountName == model.accountName).FirstOrDefault();
                    }
                    else if (!string.IsNullOrEmpty(model.email))
                    {
                        entity = _accountRepository.Query(db).Where(m => m.email == model.email).FirstOrDefault();
                    }
                    if (entity == null)
                    {
                        return new ResultModel<ResultType>(ResultType.NotExists, "账号不存在", "");
                    }
                    entity.password = SecurityHelper.Hash(radNumber.ToString());
                    entity.passwordType = PasswordType.ResetPwd;
                    int result = _accountRepository.Update(db, entity);
                    if (result < 1)
                    {
                        return new ResultModel<ResultType>(ResultType.Fail, "密码重置失败", "");
                    }
                    SendEmailTask(emailModel, entity.accountName, radNumber.ToString(), entity.email);
                    return new ResultModel<ResultType>(ResultType.Success, "", "");
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("LoginService.ForgetPassword", ex);
                return new ResultModel<ResultType>(ResultType.SystemError, "系统出错", "");
            }

            
        }
        private Task<ResultType> SendEmailTask(EmailModel model,string accountName,string password,string email)
        {
            EmailLogModel emailLogModel = new EmailLogModel();
            emailLogModel.emailBody = string.Format(model.emailBody, accountName, password);
            emailLogModel.emailSubject = model.emailSubject;
            emailLogModel.emailSendStatus = EmailSendStatus.Sending;
            emailLogModel.emailTo = email;
            emailLogModel.encodeType = EncodeType.UTF8;
            Task<ResultType> task = new Task<ResultType>(() => _emailService.SendEmail(emailLogModel));
            task.Start();
            return task;
        }

    }
}
