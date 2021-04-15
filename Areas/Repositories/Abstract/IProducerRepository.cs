using OnlineShopDuhootWeb.Areas.Identity.Data;
using System.Linq;

namespace OnlineShopDuhootWeb.Areas.Repositories.Abstract
{
    public interface IProducerRepository
    {
        public void SaveProducer(Producer entity);
        public Producer CreateNewProducer();
        public void DeleteProducer(int id);
        public IQueryable<Producer> Producers { get; }
        public Producer GetProducerById(int id);
    }
}
