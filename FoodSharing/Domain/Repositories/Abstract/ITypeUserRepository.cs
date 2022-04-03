using FoodSharing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.Domain.Repositories.Abstract
{
    public interface ITypeUserRepository
    {
        IQueryable<TypeUser> GetTypeUsers();
        TypeUser GetTypeUserById(Guid id);
        Task SaveTypeUser(TypeUser entity);
        Task DeleteTypeUser(Guid id);
        Task UpdateTypeUser(TypeUser entity);
    }
}
