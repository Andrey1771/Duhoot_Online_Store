using Microsoft.EntityFrameworkCore;
using OnlineShopDuhootWeb.Areas.Identity.Data;
using OnlineShopDuhootWeb.Areas.Repositories.Abstract;
using OnlineShopDuhootWeb.Data;
using System.Linq;

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
            dbContext.SaveChanges();
        }

        public Producer GetProducerById(int id)
        {
            return dbContext.Producers.FirstOrDefault(x => x.ProducerId == id);
        }

        public void SaveProducer(Producer entity)
        {
            Producer producer = dbContext.Producers.AsNoTracking().FirstOrDefault(x => x == entity);
            if (producer == default)
            {
                dbContext.Entry(entity).State = EntityState.Added;
            }
            else
            {
                dbContext.Entry(entity).State = EntityState.Modified;
            }
            dbContext.SaveChanges();
        }

        public Producer CreateNewProducer()
        {
            return new Producer() { ProducerId = default };
        }
    }
}
