using OnlineShopDuhootWeb.Areas.Repositories.Abstract;

namespace OnlineShopDuhootWeb.Areas.Identity.Data
{
    public class DataManager
    {
        public IProductSiteCardRepository ProductSiteCardRep { get; set; }
        public IProductRepository ProductRep {get; set;}
        public IProducerRepository ProducerRep { get; set; }

        public DataManager(IProductSiteCardRepository productSiteCardRepository, IProductRepository productRepository, IProducerRepository producerRepository)
        {
            ProductSiteCardRep = productSiteCardRepository;
            ProductRep = productRepository;
            ProducerRep = producerRepository;
        }
    }
}
