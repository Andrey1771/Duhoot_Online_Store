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
        public void SendEmail(MailMessage mailMessage)
        {
            using (SmtpClient smtp = new("smtp.gmail.com", 587))
            {
                try
                {
                    string email = SenderSettings.Email;
                    string password = SenderSettings.Password;
                    smtp.Credentials = new NetworkCredential(email, password);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Письмо не было отправлено на почту, тк файл LoginAndPassword.txt не был найден");
                }
                catch
                {
                    Console.WriteLine("Письмо не было отправлено на почту, тк возникла ошибка при считывании данных из LoginAndPassword.txt или из-за ошибки со стороны NetworkCredential");
                }

                smtp.EnableSsl = true;
                smtp.Send(mailMessage);
            }
        }
    }
}
