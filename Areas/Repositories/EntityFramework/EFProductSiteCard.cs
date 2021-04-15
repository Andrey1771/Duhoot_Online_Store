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
            dbContext.SaveChangesAsync();
        }

        public ProductSiteCard GetSiteCardById(int id)
        {
            return dbContext.ProductSiteCards.FirstOrDefault(x => x.ProductId == id);
        }

        public void SaveSiteCard(ProductSiteCard entity)
        {
            if (dbContext.ProductSiteCards.FirstOrDefault(e => e.ProductId == entity.ProductId) == default)
            {
                dbContext.Entry(entity).State = EntityState.Added;
            }
            else
            {
                /*dbContext.Entry(entity).State = EntityState.Modified;*/
            }
            dbContext.SaveChangesAsync();
        }

        public ProductSiteCard CreateNewSiteCard(int id)// TODO Потенциальная оптимизация
        {
            var cardsId = dbContext.ProductSiteCards.Select(e => e.ProductId).ToList();
            var index = EmptyIndexSearch.Search(cardsId);
            return index == -1 ? null : new ProductSiteCard() { ProductId = index};
        }
    }
}
