using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodSharing.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Fio { get; set; }
        public int CountOrder { get; set; }
        public List<Link>? Links { get; set; } = new List<Link>();
        public List<Order>? Orders { get; set; } = new List<Order>();
        public List<ListUser>? Volunteers { get; set; } = new List<ListUser>();

    }
}
