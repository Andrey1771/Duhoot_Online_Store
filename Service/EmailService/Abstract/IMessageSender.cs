using System.Net.Mail;

namespace OnlineShopDuhootWeb.Service.EmailService.Abstract
{
    public interface IMessageSender
    {
        public static SenderSettings SenderAccount { get; }
        void SendEmail(MailMessage mailMessage);
    }
}
