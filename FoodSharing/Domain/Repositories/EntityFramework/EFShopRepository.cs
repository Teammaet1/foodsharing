using FoodSharing.Domain.Entities;
using FoodSharing.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.Domain.Repositories.EntityFramework
{
    public class EFShopRepository : IShopRepository
    {
        private readonly AppDbContext context;
        public EFShopRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task DeleteShop(Guid id)
        {
            context.Shops.Remove(GetShopById(id));
            await context.SaveChangesAsync();
        }

        public Shop GetShopById(Guid id)
        {
            return context.Shops.Include(x => x.ChainShop).FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<Shop> GetShops()
        {
            return context.Shops.Include(x => x.ChainShop);
        }

        public async Task SaveShop(Shop entity)
        {
            if (entity.Id == default)
            {
                context.Shops.Add(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateShop(Shop entity)
        {
            if (GetShopById(entity.Id) != null)
            {
                context.Shops.Update(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
