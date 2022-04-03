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
    public class EFLinkRepository : ILinkRepository
    {
        private readonly AppDbContext context;
        public EFLinkRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task DeleteLink(Guid id)
        {
            context.Links.Remove(GetLinkById(id));
            await context.SaveChangesAsync();
        }

        public Link GetLinkById(Guid id)
        {
            return context.Links.FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<Link> GetLinks()
        {
            return context.Links;
        }

        public async Task SaveLink(Link entity)
        {
            if (entity.Id == default)
            {
                context.Links.Add(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateLink(Link entity)
        {
            if (GetLinkById(entity.Id) != null)
            {
                context.Links.Update(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
