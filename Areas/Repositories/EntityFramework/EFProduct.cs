using Microsoft.EntityFrameworkCore;
using OnlineShopDuhootWeb.Areas.Identity.Data;
using OnlineShopDuhootWeb.Areas.Repositories.Abstract;
using OnlineShopDuhootWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopDuhootWeb.Areas.Repositories.EntityFramework
{
    public class EFProduct : IProductRepository
    {
        public IQueryable<Product> Products => dbContext.Products;

        private readonly OnlineShopDuhootWebContext dbContext;

        public EFProduct(OnlineShopDuhootWebContext context)
        {
            dbContext = context;
        }

        public void DeleteProduct(int id)
        {
            dbContext.Remove(new Product() { ProductId = id });
            dbContext.SaveChanges();//Может не работать правильно async
        }

        public Product GetProductById(int id)
        {
            return dbContext.Products.FirstOrDefault(x => x.ProductId == id);
        }

        public void SaveProduct(Product entity)
        {
            Producer producer = dbContext.Producers.Find(entity.ProductId);
            if (producer == null)
            {
                //Ошибка, такое невозможно
                throw new ArgumentException("Ошибка, карточка сайта не привязана к продукту");
            }
            if (producer.Products.Count(e => e == entity) == 0)
            {
                /*product.SiteCard = entity;*/

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
