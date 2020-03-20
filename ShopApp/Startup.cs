using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CarShop.Interfaces;
using Microsoft.Extensions.Configuration;
using CarShop.DbRepo;
using CarShop.DbRepo.Repositories;
using Microsoft.AspNetCore.Http;
using CarShop.Models;
using Microsoft.Extensions.Hosting;

namespace CarShop
{
    //https://localhost:44308/cars/carslist use this link
    //https://localhost:44308/shopcart/index use this link
    public class Startup
    {
        private IConfigurationRoot _confString;

        public Startup(IWebHostEnvironment env)
        {
            _confString = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("dbsettings.json")
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(op =>
            {
                op.UseSqlServer(_confString.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient<ICars, CarRepo>();
            services.AddTransient<ICategory, CategoryRepo>();
            services.AddTransient<IAllOrders, OrderRepo>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddMvc(p => p.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{category?}",
                    defaults: new { Controller = "Car", action = "CarsList" });
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                DbObjects.Initialize(context);
            }
        }
    }
}
