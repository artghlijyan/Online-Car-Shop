using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CarShop.Interfaces;
using CarShop.Mocks;
using Microsoft.Extensions.Configuration;
using CarShop.DbRepo;
using CarShop.DbRepo.Repositories;

namespace CarShop
{
    //https://localhost:44308/cars/allcars use this link
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
            services.AddMvc(p => p.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
