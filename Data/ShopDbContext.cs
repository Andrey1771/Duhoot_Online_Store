using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShopDuhootWeb.Entities;

namespace OnlineShopDuhootWeb.Context
{
    public class ShopDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserPaySettings> UserPaySettings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Producer> Producers { get; set; }

        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
