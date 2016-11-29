using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Common.Utilities
{
    public class EmailHelper
    {
        public const string forgetPasswordSubject = "忘记密码邮件";
        public const string forgetPasswordBody = "你好{0}:<br/>您的密码修改为{1},登录后立即修改新的密码";
        public static readonly string emailSender = ConfigHelper.GetConfigString("EmailSender");
        public static readonly string emailSenderPwd = ConfigHelper.GetConfigString("EmailSenderPwd");
        public static readonly string smtpServer = ConfigHelper.GetConfigString("SmtpServer");
        public static readonly long forgetPasswordEmailId = ConfigHelper.GetConfigBigInt("forgetPasswordEmailId");
        public static ResultType SendEmail(string subject, string body,string to, Encoding encode, string displayName = "", string smtp = "", string emailFrom = "", string emailTo = "")
        {
            MailMessage oMail = null;
            try
            {
                MailAddress from = null;
                if (displayName == "")
                {
                    from = new MailAddress((emailFrom == "" ? emailSender : emailFrom));
                }
                else
                {
                    from = new MailAddress((emailFrom == "" ? emailSender : emailFrom), displayName);
                }

                MailAddress mailAddress = new MailAddress(to);

                oMail = new MailMessage(from, mailAddress);
                oMail.Subject = subject;//主题
                oMail.Body = body;//内容

                oMail.IsBodyHtml = true;
                oMail.BodyEncoding = encode;
                oMail.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient();
                client.Host = (smtp == "" ? smtpServer : smtp); //指定邮件服务器
                client.Credentials = new NetworkCredential(emailSender, emailSenderPwd);//指定服务器邮件,及密码 


            //发送 

                client.Send(oMail); //发送邮件 
                oMail.Dispose(); //释放资源 
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                if (oMail!=null)
                {
                    oMail.Dispose(); //释放资源 
                }
                Config.log.Error("EmailHelper.SendEmail", ex);
                return ResultType.SystemError;
                //发送不成功！


            }

           
            
        }
    }
}
