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
    public class EFTypeUserRepository : ITypeUserRepository
    {
        private readonly AppDbContext context;
        public EFTypeUserRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task DeleteTypeUser(Guid id)
        {
            context.TypeUsers.Remove(GetTypeUserById(id));
            await context.SaveChangesAsync();
        }

        public TypeUser GetTypeUserById(Guid id)
        {
            return context.TypeUsers.FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<TypeUser> GetTypeUsers()
        {
            return context.TypeUsers;
        }

        public async Task SaveTypeUser(TypeUser entity)
        {
            if (entity.Id == default)
            {
                context.TypeUsers.Add(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateTypeUser(TypeUser entity)
        {
            if (GetTypeUserById(entity.Id) != null)
            {
                context.TypeUsers.Update(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
