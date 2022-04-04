
using FoodSharing.Domain.Repositories.Abstract;

namespace FoodSharing.Domain
{
    public class DataManager
    {
        public ICategoryRepository category { get; set; }
        public IChainShopRepository chainShop { get; set; }
        public ILinkRepository link { get; set; }
        public IOrderRepository order { get; set; }
        public IProductRepository product { get; set; }
        public IShopRepository shop { get; set; }

        public DataManager(ICategoryRepository categoryRepository, IChainShopRepository chainShopRepository,
                            ILinkRepository linkRepository, IOrderRepository orderRepository,
                            IProductRepository productRepository, IShopRepository shopRepository)
        {
            category = categoryRepository;
            chainShop = chainShopRepository;
            link = linkRepository;
            order = orderRepository;
            product = productRepository;
            shop = shopRepository;
        }
    }
}
