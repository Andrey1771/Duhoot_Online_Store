using System.Net.Mail;

namespace OnlineShopDuhootWeb.Service.EmailService.Abstract
{
    public interface IMessageSender
    {
        /// <summary>
        /// Отправляет Html сообщение пользователю
        /// </summary>
        /// <param name="from">Почта отправителя</param>
        /// <param name="to">Почта получателя</param>
        /// <param name="subject">Название темы сообщения</param>
        /// <param name="titleMessage">Название сообщения</param>
        /// <param name="htmlBody">HTML тело сообщения</param>
        void SendEmail(string from, string to, string subject, string titleMessage, string htmlBody);
    }
}
