using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ServiceOrderAPI.Application.Models;
using ServiceOrderAPI.Application.Models.Context;
using ServiceOrderAPI.Data.Queries.Dapper;
using ServiceOrderAPI.Data.Queries.Dapper.Context;
using ServiceOrderAPI.Data.Queries.Dapper.Interfaces;
using ServiceOrderAPI.Data.Repositories;
using ServiceOrderAPI.Data.Repositories.Interfaces;
using System;

namespace ServiceOrderAPI
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_configuration);
            services.AddControllers();

            #region MediatR

            services.AddMediatR(typeof(Startup));
            services.AddTransient<IRepository<ServiceOrder>, ServiceOrderRepository>();

            #endregion MediatR

            #region Swagger

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Service Order API",
                        Version = "v1",
                        Description = "API Sample for Service Order with ASP.NET Core",
                        Contact = new OpenApiContact
                        {
                            Name = "João Pacheco",
                            Url = new Uri("https://github.com/jcarlosnpacheco")
                        }
                    });
            });

            #endregion Swagger

            #region DbContext

            services.AddEntityFrameworkNpgsql()
             .AddDbContext<ServiceOrderContext>(options => options.UseNpgsql(_configuration.GetConnectionString("ServiceOrderDB")));

            #endregion DbContext

            #region Dapper

            services.AddSingleton<DapperContext>();
            services.AddScoped<IServiceOrderQueries, ServiceOrderQueries>();

            #endregion Dapper
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Service Order API");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}