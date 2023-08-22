using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoponBusinessLayer.Contracts;
using ShoponBusinessLayer.Implementation;
using ShoponDataLayer.Contracts;
using ShoponDataLayer.Implementation;
using ShoponEFLayer.Implementation;
using ShoponEFLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoponWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Configure Entity Framework
            services.AddDbContext<db_shoponContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            //Configure Identity Service
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<db_shoponContext>();

            //Map ICompanyManager
            //services.AddTransient<ICompanyRepository, CompanyRepositoryDBImpl>();
            //Map ICategoryManager
            //services.AddTransient<ICategoryRepository, CategoryRepositoryDBImpl>();

            //Map IProductRepository
            //services.AddTransient<IProductRepository, ProductRepositoryDBImpl>();
            services.AddTransient<IProductRepository, ProductRepositoryEFImpl>();

            //Map IProductManager
            services.AddTransient<IProductManager, ProductManager>();

            services.AddControllersWithViews();

            //Map HttpContextAcessor
            services.AddHttpContextAccessor();
            //Map IOrderRepository
            services.AddTransient<IOrderRepository, OrderRepositoryDBImpl>();

            //Map IOrderManager
            services.AddTransient<IOrderManager, OrderManager>();



            //config sessions
            services.AddSession(options =>
            {
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(30);  //cookie expiration time
            });
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
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
