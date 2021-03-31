using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
//using OnlineShopDuhootWeb.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using OnlineShopDuhootWeb.Data;
using Microsoft.Extensions.FileProviders;
using System.IO;
using OnlineShopDuhootWeb.Service;

namespace OnlineShopDuhootWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Configuration.Bind("Project", new Config());///Проверить

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // получаем строку подключения из файла конфигурации
            string connection = Configuration.GetConnectionString("ShopDbConnection");
            // добавляем контекст UserContext в качестве сервиса в приложение
            services.AddDbContext<OnlineShopDuhootWebContext>(options =>
                options.UseSqlServer(connection));

            // добавление сервисов Idenity
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)///TODO
                        .AddEntityFrameworkStores<OnlineShopDuhootWebContext>();

            services.AddControllersWithViews();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            // добавляем поддержку каталога node_modules
            app.UseFileServer(new FileServerOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "node_modules")
                ),
                RequestPath = "/node_modules",
                EnableDirectoryBrowsing = false
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });



            
        }
    }
}
