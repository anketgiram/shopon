using EkartBussiness.Contract;
using EkartBussiness.Implementation;
using EkartData.Contract;
using EkartEF.Implementation;
using EkartEF.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EkartServices
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

            //Config IOrderManagerAsync
            services.AddTransient<IOrderManagerAsync, OrderManagerImpl>();

            //Config IOrderRepoAsync
            services.AddTransient<IOrderRepoAsync, OrderRepoAsyncImpl>();

            //config swagger
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "V1.0",
                    Description = "API for Ekart service"
                });
            });
            

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            //Swagger End point
            app.UseSwaggerUI(options =>
            {
                //sepcifing document option
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Ekart Service API V1.0");
                //for root fix
                options.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
