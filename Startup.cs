using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using OnlineShopDuhootWeb.Data;
using Microsoft.Extensions.FileProviders;
using System.IO;
using OnlineShopDuhootWeb.Service;
using OnlineShopDuhootWeb.Areas.Repositories.Abstract;
using OnlineShopDuhootWeb.Areas.Repositories.EntityFramework;
using OnlineShopDuhootWeb.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using OnlineShopDuhootWeb.Service.EmailService.Abstract;
using OnlineShopDuhootWeb.Service.EmailService.SmtpEmailService;
using OnlineShopDuhootWeb.Service.EmailService.MimeEmailService;

namespace OnlineShopDuhootWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Configuration.Bind("Project", new Config());
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 5001;
            });

            services.AddTransient<IProductSiteCardRepository, EFProductSiteCard>();
            services.AddTransient<IProductRepository, EFProduct>();
            services.AddTransient<IProducerRepository, EFProducer>();
            services.AddTransient<DataManager>();

            //Тут можно установить способ отправки
            /*services.AddTransient<IMessageSender, SmtpMessageSender>();*/
            services.AddTransient<IMessageSender, MimeMessageSender>();

            // получаем строку подключения из файла конфигурации
            string connection = Configuration.GetConnectionString("ShopDbConnection");
            // добавляем контекст UserContext в качестве сервиса в приложение
            services.AddDbContext<OnlineShopDuhootWebContext>(options =>
                options.UseSqlServer(connection));

            // добавление сервисов Idenity
            services.AddIdentity<OnlineShopDuhootWebUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;

            }).AddEntityFrameworkStores<OnlineShopDuhootWebContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "duhoot";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });

            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Добавление поддержки каталога node_modules
            app.UseFileServer(new FileServerOptions()// TODO Добавить проверку на существование папки!
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "node_modules")
                ),
                RequestPath = "/node_modules",
                EnableDirectoryBrowsing = false
            });

            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "admin",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
