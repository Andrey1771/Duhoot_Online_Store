using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineShopDuhootWeb.Areas.Identity.Data;
using OnlineShopDuhootWeb.Areas.Repositories.Abstract;
using OnlineShopDuhootWeb.Data;
using OnlineShopDuhootWeb.Service;

namespace OnlineShopDuhootWeb.Areas.Repositories.EntityFramework
{
    public class EFProductSiteCard : IProductSiteCardRepository
    {
        public IQueryable<ProductSiteCard> ProductSiteCards => dbContext.ProductSiteCards;
        private readonly OnlineShopDuhootWebContext dbContext;
        public EFProductSiteCard(OnlineShopDuhootWebContext context)
        {
            dbContext = context;
        }
        

        public void DeleteSiteCard(int id)
        {
            dbContext.Remove(new ProductSiteCard() { ProductId = id });
            dbContext.SaveChanges();
        }

        public ProductSiteCard GetSiteCardById(int id)
        {
            return dbContext.ProductSiteCards.FirstOrDefault(x => x.ProductId == id);
        }

        public void SaveSiteCard(ProductSiteCard entity)
        {
            if (dbContext.ProductSiteCards.AsNoTracking().FirstOrDefault(e => e.ProductId == entity.ProductId) == default)
            {
                dbContext.Entry(entity).State = EntityState.Added;
            }
            else
            {
                dbContext.Entry(entity).State = EntityState.Modified;
            }
            dbContext.SaveChanges();
        }

        public ProductSiteCard CreateNewSiteCard(int id)// TODO Потенциальная оптимизация
        {
            if(id == default)
            {
                var cardsId = dbContext.ProductSiteCards.Select(e => e.ProductId).ToList();
                id = EmptyIndexSearch.Search(cardsId);
            }
            
            return id == -1 ? null : new ProductSiteCard() { ProductId = id};
        }
    }
}
