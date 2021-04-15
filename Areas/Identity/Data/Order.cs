using System;
using System.Collections.Generic;

namespace OnlineShopDuhootWeb.Areas.Identity.Data
{
    public class Order
    {
        public int OrderId { get; set; }
        public OnlineShopDuhootWebUser User { get; set; }

        public string Location { get; set; }
        public DateTime DeliveryDate { get; set; }

        public List<Product> Products { get; set; }
    }
}
