using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopDuhootWeb.Areas.Identity.Data
{
    public class Product
    {
        public int ProductId { get; set; }
        public Producer Producers { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public List<Order> Orders { get; set; }
    }
}
