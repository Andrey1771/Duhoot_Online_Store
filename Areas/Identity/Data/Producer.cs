using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopDuhootWeb.Areas.Identity.Data
{
    public class Producer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProducerId { get; set; }

        public string Name { get; set; }
        public string ContactInformation { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        
        public List<Product> Products { get; set; }
    }
}
