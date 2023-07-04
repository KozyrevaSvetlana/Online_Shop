using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.Db;
using OnlineShop.Db.Helper;
using OnlineShop.Db.Models;
using Serilog;
using System.IO;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var userManager = services.GetRequiredService<UserManager<User>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                await IdentityInitializer.Initialize(userManager, roleManager);
            }
            host.Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog((hostingContent, loggerConfiguration) =>
            {
                loggerConfiguration
                .ReadFrom.Configuration(hostingContent.Configuration)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("ApplicationName", "Online Shop");
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
