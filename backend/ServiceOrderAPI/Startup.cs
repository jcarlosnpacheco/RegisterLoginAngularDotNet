using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ServiceOrderAPI.Business.Interfaces.Queries;
using ServiceOrderAPI.Business.Interfaces.Repositories;
using ServiceOrderAPI.Business.Models;
using ServiceOrderAPI.Infra.Data.Context;
using ServiceOrderAPI.Infra.Data.Queries;
using ServiceOrderAPI.Infra.Data.Queries.Dapper.Context;
using ServiceOrderAPI.Infra.Data.Repositories;
using System;

namespace ServiceOrderAPI.API
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
            //reference Handler in other class library
            var assembly = AppDomain.CurrentDomain.Load("Business");
            services.AddMediatR(assembly);
                        
            services.AddTransient<IGenericRepository<ServiceOrderModel>, ServiceOrderRepository>();

            #endregion MediatR

            #region Swagger

            services.AddSwaggerGen(options =>
            {
                var url = "https://github.com/jcarlosnpacheco";
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Service Order API",
                        Version = "v1",
                        Description = "API Sample for Service Order with ASP.NET Core",
                        Contact = new OpenApiContact
                        {
                            Name = "João Pacheco",
                            Url = new Uri(url)
                        }
                    });
            });

            #endregion Swagger

            #region DbContext

            services.AddEntityFrameworkNpgsql()
             .AddDbContext<DBServiceOrderContext>(
                options => options.UseNpgsql(_configuration.GetConnectionString("ServiceOrderDB"),
                                            b => b.MigrationsAssembly("ServiceOrderAPI"))
             );

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