using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volvo_API.Models;
using Volvo_API.Repository;
using Volvo_API.Repository.Context;
using Volvo_API.Services;

namespace Volvo_API
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
            services.AddControllers();

            services.AddDbContext<DatabaseContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("db1")));

            services.AddScoped<DatabaseContext>();

            services.AddCors(c => c.AddPolicy("CorsPolicy", builder =>
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
            ));

            services.AddScoped<IService<Truck>, TruckService>();
            services.AddScoped<IRepository<Truck>, TruckRepository>();
            services.AddScoped<IService<TruckModel>, TruckModelService>();
            services.AddScoped<IRepository<TruckModel>, TruckModelRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Volvo_API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Volvo_API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
