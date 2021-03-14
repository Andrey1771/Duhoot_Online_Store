using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopDuhootWeb.Areas.Identity.Data
{

    // Add profile data for application users by adding properties to the OnlineShopDuhootWebUser class
    public class OnlineShopDuhootWebUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime DateBirth { get; set; }
        public string Gender { get; set; }

        //Location
        public string Country { get; set; }
        public int Postcode { get; set; }
        public string Address { get; set; }

        public /*virtual*/ List<UserPaySettings> PaySettings { get; set; }
        public /*virtual*/ List<Order> Orders { get; set; }
    }
}
