using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopDuhootWeb.Areas.Identity.Data
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
        public int ProducerId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public List<Order> Orders { get; set; }
        public ProductSiteCard SiteCard { get; set; }
    }
}
