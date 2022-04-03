using FoodSharing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.Domain.Repositories.Abstract
{
    public interface IOrderRepository
    {
        IQueryable<Order> GetOrders();
        Order GetOrderById(Guid id);
        Task SaveOrder(Order entity);
        Task DeleteOrder(Guid id);
        Task UpdateOrder(Order entity);
    }
}
