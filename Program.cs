using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace OnlineShopDuhootWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (!Directory.Exists(@"node_modules"))
            {
                Directory.CreateDirectory(@"node_modules");
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
