using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShopDuhootWeb.Areas.Identity.Data;
using OnlineShopDuhootWeb.Data;

[assembly: HostingStartup(typeof(OnlineShopDuhootWeb.Areas.Identity.IdentityHostingStartup))]
namespace OnlineShopDuhootWeb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<OnlineShopDuhootWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ShopDbConnection")));

                services.AddDefaultIdentity<OnlineShopDuhootWebUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<OnlineShopDuhootWebContext>();
            });
        }
    }
}