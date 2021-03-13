using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopDuhootWeb.Entities
{
    public class User
    {
        [Key]
        public string EmailId { get; set; }

        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime DateBirth { get; set; }
        public string Gender { get; set; }

        List<UserPaySettings> PaySettings { get; set; }
        List<Order> Orders { get; set; }
    }
}
