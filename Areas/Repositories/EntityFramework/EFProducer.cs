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
    public class EFProducer : IProducerRepository
    {
        public IQueryable<Producer> Producers => dbContext.Producers;

        private readonly OnlineShopDuhootWebContext dbContext;

        public EFProducer(OnlineShopDuhootWebContext context)
        {
            dbContext = context;
        }

        public void DeleteProducer(int id)
        {
            dbContext.Remove(new Producer() { ProducerId = id });
            dbContext.SaveChanges();//Может не работать правильно async
        }

        public Producer GetProducerById(int id)
        {
            return dbContext.Producers.FirstOrDefault(x => x.ProducerId == id);
        }

        public void SaveProducer(Producer entity)
        {
            Producer producer = dbContext.Producers.FirstOrDefault(x => x == entity);//////////!!!!!
            if (producer == null)
            {
                dbContext.Entry(entity).State = EntityState.Added;
            }
            else
            {
                dbContext.Entry(entity).State = EntityState.Modified;
            }
            dbContext.SaveChanges();//Может не работать правильно async
        }

        public Producer CreateNewProducer()//TODO Потенциальная оптимизация
        {
            var producersId = dbContext.Producers.Select(e => e.ProducerId).ToList();
            var index = EmptyIndexSearch.Search(producersId);
            return index == -1 ? null : new Producer() { ProducerId = index};
        }
    }
}
