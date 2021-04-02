using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopDuhootWeb.Areas.Identity.Data
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public Producer Producer { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public List<Order> Orders { get; set; }
        public List<ProductSiteCard> SiteCards { get; set; }
    }
}
