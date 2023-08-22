using EkartBussiness.Contract;
using EkartBussiness.Implementation;
using EkartData.Contract;
using EkartEF.Implementation;
using EkartEF.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace EkartWebApp
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
            //CONFIG DB_EKARTSContext
            services.AddDbContext<db_eKARTSContext>(
              option => option.UseSqlServer(Configuration.GetConnectionString("Default"))
              );

            // Config db_eKARTSContext
            //services.AddTransient<db_eKARTSContext, db_eKARTSContext>();

            //Config Identity
            services.AddIdentity<Staff, IdentityRole>()
                  .AddEntityFrameworkStores<db_eKARTSContext>()
                  .AddDefaultTokenProviders();

            //Config ICustomerManager
            services.AddTransient<ICustomerManager, CustomerManagerImpl>();

            //Config ICustomerRepo
            //services.AddTransient<ICustomerRepo, CustomerRepoImpl>();
            services.AddTransient<ICustomerRepo, CustomerEFImpl>();

            //Config IOrder
            services.AddTransient<IOrderManager, OrderManager>();
            services.AddTransient<IOrderRepo, OrderEFImpl>();

            //Sessions Config
            services.AddSession(option =>
            {
                option.Cookie.IsEssential = true;
                option.IdleTimeout = TimeSpan.FromMinutes(30);
            });

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
