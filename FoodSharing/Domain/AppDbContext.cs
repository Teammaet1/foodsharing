using FoodSharing.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodSharing.Domain
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ChainShop> ChainShops { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ListUser> ListUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "5e6bb83b-674a-44d2-b0e7-bc755d32c185",
                Name = "tutor",
                NormalizedName = "TUTOR"
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "44546e10-8719-4ad8-b88a-f271ae9d6eab",
                Name = "volunteer",
                NormalizedName = "VOLUNTEER"
            });

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "3b62473e-4f66-49fa-a20f-e7685b9565d8",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "123"),
                SecurityStamp = string.Empty,
                Fio = "BD BD BD",
                PhoneNumber = "+7777777777",
                CountOrder = 0,
            });;

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "44546e10-8719-4ad8-b88a-f271ae9d6eab",
                UserId = "3b62473e-4f66-49fa-a20f-e7685b9565d8"
            });

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "9d173eac-8562-4aa5-9d69-a91e23905927",
                UserName = "Kera",
                NormalizedUserName = "KERA",
                Email = "me@email.com",
                NormalizedEmail = "ME@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "123"),
                SecurityStamp = string.Empty,
                Fio = "Ker Ker Ker",
                PhoneNumber = "+7777777777",
                CountOrder = 0,

            });;

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "5e6bb83b-674a-44d2-b0e7-bc755d32c185",
                UserId = "9d173eac-8562-4aa5-9d69-a91e23905927"
            });

        }
    }
}
