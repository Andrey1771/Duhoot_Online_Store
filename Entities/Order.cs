using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopDuhootWeb.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public User User{ get; set; }

        public string Location { get; set; }
        public DateTime DeliveryDate { get; set; }

        public List<Product> Products { get; set; }
    }
}
