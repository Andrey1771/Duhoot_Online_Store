using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShopDuhootWeb.Areas.Identity.Data;

namespace OnlineShopDuhootWeb.Data
{
    public class OnlineShopDuhootWebContext : IdentityDbContext<OnlineShopDuhootWebUser>
    {
        public DbSet<OnlineShopDuhootWebUser> OnlineShopDuhootWebUsers { get; set; }
        public DbSet<UserPaySettings> UserPaySettings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<ProductSiteCard> ProductSiteCards { get; set; }

        public OnlineShopDuhootWebContext(DbContextOptions<OnlineShopDuhootWebContext> options)
            : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "73538e00-1473-86ad-dffe-d63854ac1405",
                Name = "admin",
                NormalizedName = "ADMIN"
            }) ;

            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "c7429a0f-b3a6-c750e-47dd-925f84ab4ef3",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "adminPassword"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> 
            {
                RoleId = "73538e00-1473-86ad-dffe-d63854ac1405",
                UserId = "c7429a0f-b3a6-c750e-47dd-925f84ab4ef3"
            });

            var producer = new Producer
            {
                Name = "Test_Name_1_Producer",
                Location = "Test_Location_1",
                Description = "Test_Description_1",
                ContactInformation = "Test_ContactInformation_1",
                Products = new List<Product>()
            };

            var product = new Product
            {
                Name = "Test_Product",
                Description = "Test_Product_Description",
                Producer = producer,
                
            };

            

            var productSite = new ProductSiteCard
            {
                BackgroundImage = "images/footerBack.png",
                Text = "Test_Text_Product",
                Title = "Test_Title_Product",
                RightTopText = "Test_RightTopText",
                Rating = 3,
                CountComments = 3255,
                TypeCard = TypeCard.Education,
                
            };

            product.SiteCards.Add(productSite);
            producer.Products.Add(product);

            builder.Entity<Producer>().HasData(producer);
            builder.Entity<Product>().HasData(product);
            builder.Entity<ProductSiteCard>().HasData(productSite);

        }
    }
}
