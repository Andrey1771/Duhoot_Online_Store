using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopDuhootWeb.Areas.Identity.Data
{
    public class Producer
    {
        public int ProducerId { get; set; }

        public string Name { get; set; }
        public string ContactInformation { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        
        public List<Product> Products { get; set; }
    }
}
