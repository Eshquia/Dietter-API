using DataAccess;
using DataAccess.Classes;
using DataAccess.Classes.ClientDataAccesLayer;
using DataAccess.Classes.ListDataAccesLayer;
using DietterAPI.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using service;
using Service;
using Services.Services.ClientService;
using Services.Services.ListService;
using System;
using System.Text.Json.Serialization;

namespace DietterAPI
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
          
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            services.AddControllers();
            services.AddSingleton(Log.Logger);
            services.AddScoped<IDietService, DietService>();
            services.AddScoped<IListService, ListService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IFoodDataAccessLayer, FoodDataAccessLayer>();
            services.AddScoped<IListDataAccessLayer, ListDataAccessLayer>();
            services.AddScoped<IClientDataAccessLayer, ClientDataAccessLayer>();
  
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                               .AllowAnyMethod()
                                                                                .AllowAnyHeader()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

    
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });



        }
    }
}
