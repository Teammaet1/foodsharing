using FoodSharing.Domain;
using FoodSharing.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly DataManager dataManager;

        public ShopController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        [HttpGet("listChain")]
        public IEnumerable<ChainShop> GetListChain()
        {
            return dataManager.chainShop.GetChainShops();
        }

        [HttpGet("listShop/{id}")]
        public IEnumerable<Shop> GetShops(Guid id)
        {
            return dataManager.chainShop.GetChainShopById(id).Shops;
        }

        [HttpGet("shop/{id}")]
        public Shop GetShop(Guid id)
        {
            return dataManager.shop.GetShopById(id);
        }

        [HttpGet("categories/{id}")]
        public List<Category> GetCategories(Guid id)
        {
            return dataManager.shop.GetShopById(id).Categories;
        }

        [HttpGet("products/{id}")]
        public List<Product> GetProducts(Guid id)
        {
            return dataManager.category.GetCategoryById(id).Products;
        }
    }
}
