using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
                Id = "58704fbc-843e-47bc-971a-1e28bccf6501",
                Name = "admin",
                NormalizedName = "ADMIN"
            }) ;

            builder.Entity<OnlineShopDuhootWebUser>().HasData(new OnlineShopDuhootWebUser
            {
                Id = "3cc5e7b1-5d92-4e56-8149-1d895abf236c",
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
                RoleId = "58704fbc-843e-47bc-971a-1e28bccf6501",
                UserId = "3cc5e7b1-5d92-4e56-8149-1d895abf236c"
            });


            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "ddae7fb2-045e-4ca2-a67c-e4962289adad",
                Name = "client",
                NormalizedName = "CLIENT"
            });


            var producers = new List<Producer>{
                new Producer{
                Name = "Test_Name_1_Producer",
                Location = "Test_Location_1",
                Description = "Test_Description_1",
                ContactInformation = "Test_ContactInformation_1",
                ProducerId = 1
            },
                new Producer{
                Name = "Test_Name_2_Producer",
                Location = "Test_Location_2",
                Description = "Test_Description_2",
                ContactInformation = "Test_ContactInformation_2",
                ProducerId = 2
            },
                new Producer{
                Name = "Test_Name_3_Producer",
                Location = "Test_Location_3",
                Description = "Test_Description_3",
                ContactInformation = "Test_ContactInformation_3",
                ProducerId = 3
            },
                new Producer{
                Name = "Test_Name_4_Producer",
                Location = "Test_Location_4",
                Description = "Test_Description_4",
                ContactInformation = "Test_ContactInformation_4",
                ProducerId = 4
            },
                new Producer{
                Name = "Test_Name_5_Producer",
                Location = "Test_Location_5",
                Description = "Test_Description_5",
                ContactInformation = "Test_ContactInformation_5",
                ProducerId = 5
            },
                new Producer{
                Name = "Test_Name_6_Producer",
                Location = "Test_Location_6",
                Description = "Test_Description_6",
                ContactInformation = "Test_ContactInformation_6",
                ProducerId = 6
            }

            };

            var products = new List<Product>{
                new Product{
                Name = "Test_Product",
                Description = "Test_Product_Description",
                ProductId = 1,
                ProducerId = 1
            },
                new Product{
                Name = "Test_Product_2",
                Description = "Test_Product_Description_2",
                ProductId = 2,
                ProducerId = 1
            },
                new Product{
                Name = "Test_Product_3",
                Description = "Test_Product_Description_3",
                ProductId = 3,
                ProducerId = 2
            },
                new Product{
                Name = "Test_Product_4",
                Description = "Test_Product_Description_4",
                ProductId = 4,
                ProducerId = 3
            },
                new Product{
                Name = "Test_Product_5",
                Description = "Test_Product_Description_5",
                ProductId = 5,
                ProducerId = 4
            },
                new Product{
                Name = "Test_Product_6",
                Description = "Test_Product_Description_6",
                ProductId = 6,
                ProducerId = 5
            }
            };

            

            var productSites = new List<ProductSiteCard>{
                new ProductSiteCard
            {
                BackgroundImage = "images/footerBack.jpg",
                Text = "2 bedroom house for rent in Dubai",
                Title = "VISION AGENCY",
                RightTopText = "$2,990",
                Rating = 4,
                CountComments = 365,
                TypeCard = TypeCard.House,
                ProductId = 1
            },
                new ProductSiteCard
            {
                BackgroundImage = "images/footerBack.jpg",
                Text = "3 bedroom apartment in Moscow",
                Title = "Moscow Hostel",
                RightTopText = "$3,100,000",
                Rating = 5,
                CountComments = 1109,
                TypeCard = TypeCard.Human,
                ProductId = 2
            },
                new ProductSiteCard
            {
                BackgroundImage = "images/footerBack.jpg",
                Text = "High quality education and student life",
                Title = "MIET",
                RightTopText = "$5,990",
                Rating = 4,
                CountComments = 627,
                TypeCard = TypeCard.Education,
                ProductId = 3
            },
                new ProductSiteCard
            {
                BackgroundImage = "images/footerBack.jpg",
                Text = "Hookah bar and modern music club",
                Title = "Euphoria",
                RightTopText = "$99",
                Rating = 5,
                CountComments = 550,
                TypeCard = TypeCard.Music,
                ProductId = 4
            },
                new ProductSiteCard
            {
                BackgroundImage = "images/footerBack.jpg",
                Text = "Bus transportation between major cities",
                Title = "TravelSuit",
                RightTopText = "$190",
                Rating = 4,
                CountComments = 365,
                TypeCard = TypeCard.Transport,
                ProductId = 5
            }
            };


            /*product.SiteCards.Add(productSite);
            producer.Products.Add(product);*/

            builder.Entity<Producer>().HasData(producers);
            builder.Entity<Product>().HasData(products);
            builder.Entity<ProductSiteCard>().HasData(productSites);

        }
    }
}