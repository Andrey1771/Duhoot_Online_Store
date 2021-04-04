using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShopDuhootWeb.Areas.Identity.Data;
using OnlineShopDuhootWeb.Areas.Repositories.Abstract;
using OnlineShopDuhootWeb.Data;

namespace OnlineShopDuhootWeb.Areas.Repositories.EntityFramework
{
    public class EFProductSiteCard : IProductSiteCardRepository
    {
        private readonly OnlineShopDuhootWebContext dbContext;
        public EFProductSiteCard(OnlineShopDuhootWebContext context)
        {
            dbContext = context;
        }

        public IQueryable<ProductSiteCard> ProductSiteCards => dbContext.ProductSiteCards;

        public void DeleteSiteCard(int id)
        {
            dbContext.Remove(new ProductSiteCard() { ProductCardId = id });
            dbContext.SaveChanges();//Может не работать правильно async
        }

        public ProductSiteCard GetSiteCardById(int id)
        {
            return dbContext.ProductSiteCards.FirstOrDefault(x => x.ProductCardId == id);
        }

        public void SaveSiteCard(ProductSiteCard entity)
        {
            if(entity.ProductCardId == default)
            {
                dbContext.Entry(entity).State = EntityState.Added;
            }
            else
            {
                dbContext.Entry(entity).State = EntityState.Modified;
            }
            dbContext.SaveChanges();//Может не работать правильно async
        }
    }
}
