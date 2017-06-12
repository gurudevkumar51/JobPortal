using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalDAL.Common
{
    public static class GenericClass
    {
        public static string Hash(string value)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(value))
                );
        }

        public static string IntToStringMonth(int value)
        {
            string month = "";
            switch (value)
            {
                case 1:
                    month = "January"; break;
                case 2:
                    month = "February"; break;
                case 3:
                    month = "March"; break;
                case 4:
                    month = "April"; break;
                case 5:
                    month = "May"; break;
                case 6:
                    month = "June"; break;
                case 7:
                    month = "July"; break;
                case 8:
                    month = "August"; break;
                case 9:
                    month = "September"; break;
                case 10:
                    month = "October"; break;
                case 11:
                    month = "November"; break;
                case 12:
                    month = "December"; break;
                default:
                    month = "invalid Month number";
                    break;
            }
            return month;
        }

        //public static Boolean sendMail(EmailTemplate mailDetails, SmtpMail smtpDetails)
        //{
        //    MailMessage mail = new MailMessage();
        //    mail.To.Add(mailDetails.Mail_To);
        //    if(!String.IsNullOrEmpty(mailDetails.Mail_bcc))
        //    mail.Bcc.Add(mailDetails.Mail_bcc);
        //    if (!String.IsNullOrEmpty(mailDetails.Mail_Cc))
        //    mail.CC.Add(mailDetails.Mail_Cc);
        //    if (!String.IsNullOrEmpty(Convert.ToString(smtpDetails.Smtp_mailfrom)))
        //    mail.From = new MailAddress(smtpDetails.Smtp_mailfrom);
        //    mail.Subject = mailDetails.Mail_Subject;
        //    string Body = mailDetails.Mail_Content;
        //    mail.Body = Body;
        //    mail.IsBodyHtml = true;

        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = smtpDetails.Smtp_Host;
        //    smtp.Port = smtpDetails.Smtp_Port;
        //    smtp.UseDefaultCredentials = false;
        //    smtp.Credentials = new System.Net.NetworkCredential(smtpDetails.Smtp_username, smtpDetails.Smtp_password);
        //    smtp.EnableSsl = true;
        //    smtp.Send(mail);
        //    return false;
        //}
    }
}
