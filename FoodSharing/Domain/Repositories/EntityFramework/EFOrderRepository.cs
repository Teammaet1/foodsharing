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
    public class EFOrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;
        public EFOrderRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task DeleteOrder(Guid id)
        {
            context.Orders.Remove(GetOrderById(id));
            await context.SaveChangesAsync();
        }

        public Order GetOrderById(Guid id)
        {
            return context.Orders.Include(x => x.Products).ThenInclude(x => x.Product).Include(x => x.shop).ThenInclude(x => x.Chain).FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<Order> GetOrders()
        {
            return context.Orders.Include(x => x.shop).ThenInclude(x => x.Chain).Include(x => x.Products);
        }

        public async Task SaveOrder(Order entity)
        {
            if (entity.Id == default)
            {
                context.Orders.Add(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateOrder(Order entity)
        {
            if (GetOrderById(entity.Id) != null)
            {
                context.Orders.Update(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
