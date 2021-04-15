using Microsoft.EntityFrameworkCore;
using OnlineShopDuhootWeb.Areas.Identity.Data;
using OnlineShopDuhootWeb.Areas.Repositories.Abstract;
using OnlineShopDuhootWeb.Data;
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
            dbContext.Remove(new Product() { ProductId = id });
            dbContext.SaveChangesAsync();
        }

        public Product GetProductById(int id)
        {
            return dbContext.Products.FirstOrDefault(x => x.ProductId == id);
        }

        public void SaveProduct(Product entity)
        {
            Producer producer = dbContext.Producers.Find(entity.ProducerId);
            if (producer == null)
            {
                // Ошибка, такое невозможно
                throw new ArgumentException("Ошибка, производителя нет для конкретного продукта");
            }
            if ((producer.Products == null) || (producer.Products.Count(e => e.ProductId == entity.ProductId) == 0))
            {
                dbContext.Entry(entity).State = EntityState.Added;
            }
            else
            {
                dbContext.Entry(entity).State = EntityState.Modified;
            }
            dbContext.SaveChangesAsync();
        }

        public Product CreateNewProduct()
        {
            return new Product() { ProductId = default };
        }
    }
}
