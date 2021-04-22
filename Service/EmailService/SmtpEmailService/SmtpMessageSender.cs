using OnlineShopDuhootWeb.Areas.Identity.Data;
using OnlineShopDuhootWeb.Service.EmailService.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopDuhootWeb.Service.EmailService.SmtpEmailService
{
    public class SmtpMessageSender : IMessageSender
    {
        private const int port = 587;
        public void SendEmail(string from, string to, string subject, string titleMessage, string htmlBody)
        {
            try
            {
                MailAddress fromMail = new(from, titleMessage);
                MailAddress toMail = new(to);
                MailMessage mailMessage = new(fromMail, toMail);
                mailMessage.Subject = subject;
                mailMessage.Body = htmlBody;
                mailMessage.IsBodyHtml = true;

                using (SmtpClient smtp = new(SenderSettings.SmtpEmail, port))
                {
                    string email = SenderSettings.Email;
                    string password = SenderSettings.Password;
                    smtp.Credentials = new NetworkCredential(email, password);

                    smtp.EnableSsl = true;
                    smtp.Send(mailMessage);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Письмо не было отправлено на почту, Ошибка: {e.Message}");
            }
        }
    }
}
