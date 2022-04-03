using FoodSharing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.Domain.Repositories.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> GetProducts();
        Product GetProductById(Guid id);
        Task SaveProduct(Product entity);
        Task DeleteProduct(Guid id);
        Task UpdateProduct(Product entity);
    }
}
