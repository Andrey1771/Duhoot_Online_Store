using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopDuhootWeb.Service.EmailService
{
    public static class SenderSettings
    {
        public static string Email { get; set; }
        public static string Password { get; set; }
        public static string SmtpEmail { get { return "smtp.gmail.com"; } }

        static SenderSettings()
        {
            try
            {
                // Файл должен содержать данные поля:
                // Email
                // Password
                using StreamReader reader = new(@"LoginAndPassword.txt");// TODO На настоящем сервере, этого не будет
                Email = reader.ReadLine();
                Password = reader.ReadLine();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Письмо не было отправлено на почту, тк файл LoginAndPassword.txt не был найден");
            }
            catch
            {
                Console.WriteLine("Письмо не было отправлено на почту, тк возникла ошабка при считывании данных из LoginAndPassword.txt");
            }

        }
    }
}
