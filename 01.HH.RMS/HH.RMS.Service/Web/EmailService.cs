using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity.Web;
using HH.RMS.Repository.EntityFramework;
using HH.RMS.Repository.EntityFramework.Interface;
using HH.RMS.Service.Web.Interface;
using HH.RMS.Service.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web
{
    public class EmailService : IEmailService
    {
        private IRepository<EmailEntity> _emailRepository { get; set; }
        private IRepository<EmailLogEntity> _emailLogRepository { get; set; }
        public EmailService(IRepository<EmailEntity> emailRepository, IRepository<EmailLogEntity> emailLogRepository)
        {
            _emailRepository = emailRepository;
            _emailLogRepository = emailLogRepository;
        }
        public ResultType SendEmail(EmailLogModel model)
        {
            var entity = EmailLogModel.EntityMapper<EmailLogEntity>(model);
            using (var db = new ApplicationDbContext())
            {
                _emailLogRepository.Insert(db, entity);
                ResultType result = EmailHelper.SendEmail(model.emailSubject, model.emailBody, model.emailTo, model.encode);
                if (result == ResultType.Success)
                {
                    entity.emailSendStatus = EmailSendStatus.Success;
                }
                else
                {
                    entity.emailSendStatus = EmailSendStatus.Fail;
                }
                _emailLogRepository.Update(db, entity);
                return result;
            }
        }
        public ResultType InsertEmail(EmailModel model)
        {
            var entity = EmailModel.EntityMapper<EmailEntity>(model);
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    int result = _emailRepository.Insert(db, entity);
                    if (result < 1)
                    {
                        return ResultType.Fail;
                    }
                    return ResultType.Success;
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("EmailService.InsertEmail", ex);
                return ResultType.SystemError;
            }
        }

        public EmailModel QueryEmailById(long id)
        {
            
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var entity = _emailRepository.Query(db).Where(m => m.id == id).FirstOrDefault();
                    if (entity == null)
                    { 
                        return null;
                    }
                    return EmailModel.EntityMapper<EmailModel>(entity);
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("EmailService.InsertEmail", ex);
                return null;
            }
        }

        public ResultType InsertEmailLog(EmailLogModel model)
        {
            var entity = EmailLogModel.EntityMapper<EmailLogEntity>(model);
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    int result = _emailLogRepository.Insert(db, entity);
                    if (result < 1)
                    {
                        return ResultType.Fail;
                    }
                    return ResultType.Success;
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("EmailService.InsertEmail", ex);
                return ResultType.SystemError;
            }
        }
        public ResultType UpdateEmailLogStatus(EmailLogModel model)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    _emailLogRepository.Update(db, m=>new EmailLogEntity() { emailSendStatus = model.emailSendStatus, remark= model.remark }, m => m.id == model.id);
                    return ResultType.Success;
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("EmailService.UpdateEmailLogStatus", ex);
                return ResultType.SystemError;
            }
        }
    }
}
