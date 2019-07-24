using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace INFRASTRUCTURE
{
    public class SendEmail
    {
        #region SingletonPattern

        private static SendEmail SendEmailObj = null;
        private SendEmail() { }
        public static SendEmail GetInstance()
        {
            if (SendEmailObj == null)
            {
                SendEmailObj = new SendEmail();
            }
            return SendEmailObj;
        }

        #endregion

        public bool RecoveryPassword_SendMail(string email, string password)
        {
            SmtpClient smtpClient = ConfigGmailServer();
            MailMessage mailMessage = ConfigMail(email,password);
            try
            {
                smtpClient.Send(mailMessage);
                mailMessage.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        private SmtpClient ConfigGmailServer()
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("teachersranking@gmail.com", "qwzx25ERcv80TRANKSID");

            return smtp;
        }

        private MailMessage ConfigMail(string email, string password)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = "Recuperacion de Contraseña";
            mailMessage.Body = "Su contraseña para la plataforma TeachersRanking es: " + password;
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.Normal;
            return mailMessage;
        }
    }
}
