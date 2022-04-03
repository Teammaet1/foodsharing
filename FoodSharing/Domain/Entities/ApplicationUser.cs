using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodSharing.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Fio { get; set; }
        public int CountOrder { get; set; }
        public List<Link> Links { get; set; } = new List<Link>();
        public List<TypeUser> TypeUsers { get; set; } = new List<TypeUser>();

    }
}
