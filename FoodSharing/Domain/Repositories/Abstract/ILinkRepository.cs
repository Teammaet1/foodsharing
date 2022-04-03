using FoodSharing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.Domain.Repositories.Abstract
{
    public interface ILinkRepository
    {
        IQueryable<Link> GetLinks();
        Link GetLinkById(Guid id);
        Task SaveLink(Link entity);
        Task DeleteLink(Guid id);
        Task UpdateLink(Link entity);
    }
}
