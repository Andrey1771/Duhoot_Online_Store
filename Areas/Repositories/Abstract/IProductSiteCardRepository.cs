using OnlineShopDuhootWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopDuhootWeb.Areas.Identity.Data;

namespace OnlineShopDuhootWeb.Areas.Repositories.Abstract
{
    public interface IProductSiteCardRepository
    {
        
        public void SaveSiteCard(ProductSiteCard entity);
        public void DeleteSiteCard(int id);
        public IQueryable<ProductSiteCard> ProductSiteCards { get; }
        public ProductSiteCard GetSiteCardById(int id);
    }
}
