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
        public DbSet<TypeUser> TypeUsers { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        //    {
        //        Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
        //        Name = "admin",
        //        NormalizedName = "ADMIN"
        //    });

        //    modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        //    {
        //        Id = "44546e05-8719-4ad8-b88a-f271ae9d6eab",
        //        Name = "user",
        //        NormalizedName = "USER"
        //    });

        //    modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
        //    {
        //        Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
        //        UserName = "admin",
        //        NormalizedUserName = "ADMIN",
        //        Email = "my@email.com",
        //        NormalizedEmail = "MY@EMAIL.COM",
        //        EmailConfirmed = true,
        //        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
        //        SecurityStamp = string.Empty
        //    });

        //    modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
        //    {
        //        Id = "3b62472e-4f66-49fa-a20f-e7685b9565d9",
        //        UserName = "user",
        //        NormalizedUserName = "USER",
        //        Email = "mee@email.com",
        //        NormalizedEmail = "MEE@EMAIL.COM",
        //        EmailConfirmed = true,
        //        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
        //        SecurityStamp = string.Empty
        //    });

        //    modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        //    {
        //        RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
        //        UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
        //    });

        //    modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        //    {
        //        RoleId = "44546e05-8719-4ad8-b88a-f271ae9d6eab",
        //        UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d9"
        //    });
        //}
    }
}
