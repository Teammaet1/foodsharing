using FoodSharing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.Domain.Repositories.Abstract
{
    public interface IChainShopRepository
    {
        IQueryable<ChainShop> GetChainShops();
        ChainShop GetChainShopById(Guid id);
        Task SaveChainShop(ChainShop entity);
        Task DeleteChainShop(Guid id);
        Task UpdateChainShop(ChainShop entity);
    }
}
