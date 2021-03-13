using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopDuhootWeb.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public Producer producers { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public List<Order> Orders { get; set; }
    }
}
