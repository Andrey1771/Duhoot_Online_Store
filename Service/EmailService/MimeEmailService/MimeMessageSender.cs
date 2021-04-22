using OnlineShopDuhootWeb.Service.EmailService.Abstract;
using System;
using System.Net.Mail;
using MimeKit;
namespace OnlineShopDuhootWeb.Service.EmailService.MimeEmailService
{
    public class MimeMessageSender : IMessageSender
    {
        private const int port = 465;

        public void SendEmail(string from, string to, string subject, string titleMessage, string htmlBody)
        {
            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress(titleMessage, from));
                message.To.Add(MailboxAddress.Parse(to));
                message.Subject = subject;
                message.Body = new BodyBuilder() { HtmlBody = htmlBody }.ToMessageBody();
                
                using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect(SenderSettings.SmtpEmail, port, true);
                    client.Authenticate(SenderSettings.Email, SenderSettings.Password);
                    client.Send(message);

                    client.Disconnect(true);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Письмо не было отправлено на почту, Ошибка: {e.Message}");
            }
        }
    }
}