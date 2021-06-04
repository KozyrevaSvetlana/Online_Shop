using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Db;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Models;
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
            string connection = Configuration.GetConnectionString("online_shop_kozyreva");
            services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(connection));

            services.AddTransient<IProductsRepository, ProductsDbRepository>();
            services.AddTransient<ICartsRepository, CartsDbRepository>();
            services.AddSingleton<ICompareRepository, InMemoryCompareRepository>();
            services.AddSingleton<IFavoritesRepository, InMemoryFavoritesRepository>();
            services.AddTransient<IOrdersRepository, OrdersDbRepository>();
            services.AddSingleton<IRolesRepository, InMemoryRolesRepository>();
            services.AddSingleton<IUsersRepository, InMemorUsersRepository>();
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
                    name: "MyArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}/{sign?}");
            });
        }
    }
}
