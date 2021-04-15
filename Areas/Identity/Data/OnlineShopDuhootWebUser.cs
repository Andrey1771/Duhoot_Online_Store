using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace OnlineShopDuhootWeb.Areas.Identity.Data
{
    public class OnlineShopDuhootWebUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime DateBirth { get; set; }
        public string Gender { get; set; }

        // Location
        public string Country { get; set; }
        public int Postcode { get; set; }
        public string Address { get; set; }

        public List<UserPaySettings> PaySettings { get; set; }
        public List<Order> Orders { get; set; }
    }
}
