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
    public class EFChainShopRepository : IChainShopRepository
    {
        private readonly AppDbContext context;
        public EFChainShopRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task DeleteChainShop(Guid id)
        {
            context.ChainShops.Remove(GetChainShopById(id));
            await context.SaveChangesAsync();
        }

        public ChainShop GetChainShopById(Guid id)
        {
            return context.ChainShops.Include(x => x.Shops).FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<ChainShop> GetChainShops()
        {
            return context.ChainShops.Include(x => x.Shops);
        }

        public async Task SaveChainShop(ChainShop entity)
        {
            if (entity.Id == default)
            {
                context.ChainShops.Add(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateChainShop(ChainShop entity)
        {
            if (GetChainShopById(entity.Id) != null)
            {
                context.ChainShops.Update(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
