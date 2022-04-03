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
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;
        public EFCategoryRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task DeleteCategory(Guid id)
        {
            context.Categories.Remove(GetCategoryById(id));
            await context.SaveChangesAsync();
        }

        public Category GetCategoryById(Guid id)
        {
            return context.Categories.Include(x => x.Products).FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<Category> GetCatigories()
        {
            return context.Categories.Include(x => x.Products);
        }

        public async Task SaveCategory(Category entity)
        {
            if (entity.Id == default)
            {
                context.Categories.Add(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateCategory(Category entity)
        {
            if(GetCategoryById(entity.Id) != null)
            {
                context.Categories.Update(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
