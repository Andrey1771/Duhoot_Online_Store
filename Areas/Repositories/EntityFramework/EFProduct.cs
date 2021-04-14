using Microsoft.EntityFrameworkCore;
using OnlineShopDuhootWeb.Areas.Identity.Data;
using OnlineShopDuhootWeb.Areas.Repositories.Abstract;
using OnlineShopDuhootWeb.Data;
using OnlineShopDuhootWeb.Service;
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
            Producer producer = dbContext.Producers.Find(entity.ProducerId);
            if (producer == null)
            {
                // Ошибка, такое невозможно
                throw new ArgumentException("Ошибка, производителя нет для конкретного продукта");
            }
            if ((producer.Products == null) || (producer.Products.Count(e => e.ProductId == entity.ProductId) == 0))
            {
                /*product.SiteCard = entity;*/
                dbContext.Entry(entity).State = EntityState.Added;
                /*dbContext.*/
            }
            else
            {
                dbContext.Entry(entity).State = EntityState.Modified;
            }
/*            dbContext.Attach(entity);*/
            /*dbContext.Attach(producer);
            dbContext.Entry(producer).State = EntityState.Modified;*/
            /*entity.Producer = producer;
            producer.Products.Add(entity);
            dbContext.Entry(producer).State = EntityState.Modified;*/
            dbContext.SaveChanges();// Может не работать правильно async
        }

        public Product CreateNewProduct()// TODO Потенциальная оптимизация
        {
            /*var productsId = dbContext.Products.Select(e => e.ProductId).ToList();
            var index = EmptyIndexSearch.Search(productsId);*/
            return new Product() { ProductId = default };
        }
    }
}
