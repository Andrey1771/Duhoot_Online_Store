using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopDuhootWeb.Models
{

    public enum GenderType { 
        Man, Woman
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Почта")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Имя")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [DataType(DataType.Text)]
        public string SecondName { get; set; }

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime DateBirth { get; set; }

        [Display(Name = "Страна")]
        [DataType(DataType.Text)]
        public string Country { get; set; }

        [Display(Name = "Почтовый индекс")]
        [DataType(DataType.PostalCode)]
        public int PostCode { get; set; }

        [Display(Name = "Адрес")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Display(Name = "Пол")]
        public GenderType Gender { get; set; }/*Not used*/

        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }


    }
}
