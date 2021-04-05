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


/*
 
<a href="" class="card @typeCard active">
    <div class="card-content">

        <div class="card__image">
            <img class="card__bg" src="@Model.BackgroundImage" alt="backgroundCard">
            <div class="card__price @bgCard">
                @Model.RightTopText
            </div>
            <div class="card__icon @bgCard">
                <img @imgProperties class="filter__icon">
            </div>


        </div>


        <div class="card-text">
            <h2>@Model.Title</h2>
            <p>@Model.Text</p>

            <div class="card-text-stars">
                @for (int i = 0; i < Model.Rating; ++i)
                {
                    <img src="images/star.svg">
                }
                @for (int i = 0; Model.Rating + i < 5; ++i)
                {
                    <img src="images/emptyStar.svg">
                }
                <p>@Model.CountComments</p>
            </div>
        </div>
    </div>
</a>


 
 <a href="" class="card green__card active">
                <div class="card-content">

                    <div class="card__image">
                        <img class="card__bg" src="~/images/cardBack.jpg" alt="background">
                        <div class="card__price green__bg">
                            $2,990
                        </div>
                        <div class="card__icon green__bg">
                            <img src="~/images/houseWhite.svg" alt="house.svg" class="filter__icon">
                        </div>
                    </div>


                    <div class="card-text">
                        <h2>Vision Agency</h2>
                        <p>2 bedroom house for rent in Dubai</p>

                        <div class="card-text-stars">
                            <img src="~/images/star.svg">
                            <!--Надо будет создать аналог прогресс бара, который будет создаваться на C# в html-->
                            <img src="~/images/star.svg">
                            <img src="~/images/star.svg">
                            <img src="~/images/star.svg">
                            <img src="~/images/emptyStar.svg">
                            <p>(365)</p>
                        </div>
                    </div>
                </div>
            </a>


            <a href="" class="card green__card active">
                <div class="card-content">

                    <div class="card__image">
                        <img class="card__bg" src="~/images/cardBack.jpg" alt="background">
                        <div class="card__price green__bg">
                            $3000
                        </div>
                        <div class="card__icon green__bg">
                            <img src="~/images/houseWhite.svg" alt="house.svg" class="filter__icon">
                        </div>
                    </div>


                    <div class="card-text">
                        <h2>Central City Park</h2>
                        <p>Walk through the largest and most modern park</p>

                        <div class="card-text-stars">
                            <img src="~/images/star.svg">
                            <!--Надо будет создать аналог прогресс бара, который будет создаваться на C# в html-->
                            <img src="~/images/star.svg">
                            <img src="~/images/star.svg">
                            <img src="~/images/star.svg">
                            <img src="~/images/star.svg">
                            <p>(3890)</p>
                        </div>
                    </div>
                </div>
            </a>


            <a href="" class="card red__card active">
                <div class="card-content">

                    <div class="card__image">
                        <img class="card__bg" src="~/images/cardBack.jpg" alt="background">
                        <div class="card__price red__bg">
                            $3,100,000
                        </div>
                        <div class="card__icon red__bg">
                            <img src="~/images/girlWhite.svg" alt="girl.svg" class="filter__icon">
                        </div>
                    </div>


                    <div class="card-text">
                        <h2>Moscow Hostel</h2>
                        <p>3 bedroom apartment in Moscow</p>

                        <div class="card-text-stars">
                            <img src="~/images/star.svg">
                            <!--Надо будет создать аналог прогресс бара, который будет создаваться на C# в html-->
                            <img src="~/images/star.svg">
                            <img src="~/images/star.svg">
                            <img src="~/images/star.svg">
                            <img src="~/images/star.svg">
                            <p>(1109)</p>
                        </div>
                    </div>
                </div>
            </a>


            <a href="" class="card blue__card active">
                <div class="card-content">

                    <div class="card__image">
                        <img class="card__bg" src="images/cardBack.jpg" alt="background">
                        <div class="card__price blue__bg">
                            $5,990
                        </div>
                        <div class="card__icon blue__bg">
                            <img src="images/hatWhite.svg" alt="hat.svg" class="filter__icon">
                        </div>
                    </div>


                    <div class="card-text">
                        <h2>MIET</h2>
                        <p>High quality education and student life</p>

                        <div class="card-text-stars">
                            <img src="images/star.svg">
                            <!--Надо будет создать аналог прогресс бара, который будет создаваться на C# в html-->
                            <img src="images/emptyStar.svg">
                            <img src="images/emptyStar.svg">
                            <img src="images/emptyStar.svg">
                            <img src="images/emptyStar.svg">
                            <p>(3)</p>
                        </div>
                    </div>
                </div>
            </a>


            <a href="" class="card orange__card active">
                <div class="card-content">

                    <div class="card__image">
                        <img class="card__bg" src="images/cardBack.jpg" alt="background">
                        <div class="card__price orange__bg">
                            $99
                        </div>
                        <div class="card__icon orange__bg">
                            <img src="images/musicWhite.svg" alt="music.svg" class="filter__icon">
                        </div>
                    </div>


                    <div class="card-text">
                        <h2>Euphoria</h2>
                        <p>Hookah bar and modern music club</p>

                        <div class="card-text-stars">
                            <img src="images/star.svg">
                            <!--Надо будет создать аналог прогресс бара, который будет создаваться на C# в html-->
                            <img src="images/star.svg">
                            <img src="images/star.svg">
                            <img src="images/star.svg">
                            <img src="images/star.svg">
                            <p>(550)</p>
                        </div>
                    </div>
                </div>
            </a>


            <a href="" class="card purple__card active">
                <div class="card-content">

                    <div class="card__image">
                        <img class="card__bg" src="images/cardBack.jpg" alt="background">
                        <div class="card__price purple__bg">
                            $190
                        </div>
                        <div class="card__icon purple__bg">
                            <img src="images/busWhite.svg" alt="bus.svg" class="filter__icon">
                        </div>
                    </div>


                    <div class="card-text">
                        <h2>TravelSuit</h2>
                        <p>Bus transportation between major cities</p>

                        <div class="card-text-stars">
                            <img src="images/star.svg">
                            <!--Надо будет создать аналог прогресс бара, который будет создаваться на C# в html-->
                            <img src="images/star.svg">
                            <img src="images/star.svg">
                            <img src="images/star.svg">
                            <img src="images/emptyStar.svg">
                            <p>(990)</p>
                        </div>
                    </div>
                </div>
            </a>
 
 
 */