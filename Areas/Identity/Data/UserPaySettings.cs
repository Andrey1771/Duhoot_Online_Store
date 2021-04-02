using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopDuhootWeb.Areas.Identity.Data
{
    public class UserPaySettings
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserPaySettingsId { get; set; }
        public /*virtual*/ OnlineShopDuhootWebUser User { get; set; }

        public uint NumberCard { get; set; }
        public DateTime ValidDate { get; set; }
        public string OwnerName { get; set; }

    }
}
