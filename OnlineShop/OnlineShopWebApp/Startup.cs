using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShop.Db.Repositories;
using OnlineShopWebApp.Configuration;
using OnlineShopWebApp.Helpers;
using Serilog;
using System;

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
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));

            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connection));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(8);
                options.LoginPath = "/Login/Index";
                options.LogoutPath = "/Login/Logout";
                options.Cookie = new CookieBuilder
                {
                    IsEssential = true
                };
            });
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IProductsRepository, ProductsDbRepository>();
            services.AddTransient<ICartsRepository, CartsDbRepository>();
            services.AddTransient<ICompareRepository, CompareDbRepository>();
            services.AddTransient<IFavoritesRepository, FavoritesDbRepository>();
            services.AddTransient<IOrdersRepository, OrdersDbRepository>();
            services.AddTransient<IMailService, EmailService>();
            services.AddControllersWithViews();
            services.AddTransient<ImagesProvider>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 2;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
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

            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseSerilogRequestLogging();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
