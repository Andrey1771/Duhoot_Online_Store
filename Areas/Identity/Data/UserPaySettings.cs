using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopDuhootWeb.Areas.Identity.Data
{
    public class UserPaySettings
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserPaySettingsId { get; set; }
        public OnlineShopDuhootWebUser User { get; set; }

        public uint NumberCard { get; set; }
        public DateTime ValidDate { get; set; }
        public string OwnerName { get; set; }

    }
}
