using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;
using Serilog;

namespace OnlineShopWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IProductsRepository, InMemoryProductsRepository>();
            services.AddSingleton<ICartsRepository, InMemoryCartsRepository>();
            services.AddSingleton<ICompareRepository, InMemoryCompareRepository>();
            services.AddSingleton<IFavoritesRepository, InMemoryFavoritesRepository>();
            services.AddSingleton<IOrdersRepository, InMemoryOrdersRepository>();
            services.AddSingleton<IRolesRepository, InMemoryRolesRepository>();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSerilogRequestLogging();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}/{sign?}");
            });
        }
    }
}
