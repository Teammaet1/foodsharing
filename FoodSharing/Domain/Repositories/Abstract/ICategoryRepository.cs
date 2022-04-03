using FoodSharing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.Domain.Repositories.Abstract
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetCatigories();
        Category GetCategoryById(Guid id);
        Task SaveCategory(Category entity);
        Task DeleteCategory(Guid id);
        Task UpdateCategory(Category entity);
    }
}
