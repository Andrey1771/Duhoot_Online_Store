using Microsoft.EntityFrameworkCore;
using OnlineShopDuhootWeb.Areas.Identity.Data;
using OnlineShopDuhootWeb.Areas.Repositories.Abstract;
using OnlineShopDuhootWeb.Data;
using OnlineShopDuhootWeb.Service;
using System;
using System.Linq;

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
            /*dbContext.Remove(new ProductSiteCard() { ProductId = id });*/

            dbContext.Remove(new Product() { ProductId = id });
            dbContext.SaveChanges();
        }

        public Product GetProductById(int id)
        {
            return dbContext.Products.FirstOrDefault(x => x.ProductId == id);
        }

        public void SaveProduct(Product entity)
        {
            Producer producer = dbContext.Producers.AsNoTracking().FirstOrDefault(e => e.ProducerId == entity.ProducerId);

            if (producer == default)
            {
                // Ошибка, такое невозможно
                throw new ArgumentException("Ошибка, производителя нет для конкретного продукта");
            }
            if ((producer.Products == null) || (!producer.Products.Any(e => e.ProductId == entity.ProductId)))
            {
                dbContext.Entry(entity).State = EntityState.Added;
            }
            else
            {
                dbContext.Entry(entity).State = EntityState.Modified;
            }
            dbContext.SaveChanges();
        }

        public Product CreateNewProduct()
        {
            return new Product() { ProductId = default };
        }
    }
}
