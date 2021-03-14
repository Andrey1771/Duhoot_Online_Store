using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopDuhootWeb.Areas.Identity.Data
{
    public class Order
    {
        public int OrderId { get; set; }
        public /*virtual*/ OnlineShopDuhootWebUser User { get; set; }

        public string Location { get; set; }
        public DateTime DeliveryDate { get; set; }

        public List<Product> Products { get; set; }
    }
}
