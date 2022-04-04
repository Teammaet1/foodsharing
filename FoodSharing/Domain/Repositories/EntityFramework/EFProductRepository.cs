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
    public class EFProductRepository : IProductRepository
    {
        private readonly AppDbContext context;
        public EFProductRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task DeleteProduct(Guid id)
        {
            context.Products.Remove(GetProductById(id));
            await context.SaveChangesAsync();
        }

        public Product GetProductById(Guid id)
        {
            return context.Products.FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<Product> GetProducts()
        {
            return context.Products.Include(x => x.Orders);
        }

        public async Task SaveProduct(Product entity)
        {
            if (entity.Id == default)
            {
                context.Products.Add(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateProduct(Product entity)
        {
            if (GetProductById(entity.Id) != null)
            {
                context.Products.Update(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
