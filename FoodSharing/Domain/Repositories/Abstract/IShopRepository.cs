using FoodSharing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.Domain.Repositories.Abstract
{
    public interface IShopRepository
    {
        IQueryable<Shop> GetShops();
        Shop GetShopById(Guid id);
        Task SaveShop(Shop entity);
        Task DeleteShop(Guid id);
        Task UpdateShop(Shop entity);
    }
}
