using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopDuhootWeb.Entities
{
    public class UserPaySettings
    {
        public int UserPaySettingsId { get; set; }
        public User User { get; set; }

        public uint NumberCard { get; set; }
        public DateTime ValidDate { get; set; }
        public string OwnerName { get; set; }

    }
}
