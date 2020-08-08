using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Store.API.Application.Interaces;
using Store.API.Application.Services;
using Store.Persistance.Contexts;
using AutoMapper;

namespace Store.API
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
            //Web API Controllers to Services Collection;
            services.AddControllers();
            // Register the context for Sql Server
            services.AddDbContext<STOREContext>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("StoreConnection")));
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
            //Register AutoMapper 
            services.AddAutoMapper(typeof(Startup));
            //Register Logic Services
            services.AddTransient<IPositionService, PositionService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IStationService, StationService>();
            services.AddTransient<IVehiculeService, VehiculeService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
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
