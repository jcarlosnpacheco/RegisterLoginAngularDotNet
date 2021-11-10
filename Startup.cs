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
using ServiceOrderAPI.Repositories;
using System;

namespace ServiceOrderAPI
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
                            Name = "Jo�o Pacheco",
                            Url = new Uri("https://github.com/jcarlosnpacheco")
                        }
                    });
            });

            #endregion Swagger

            #region DbContext
            services.AddEntityFrameworkNpgsql()
             .AddDbContext<ServiceOrderContext>(options => options.UseNpgsql(Configuration.GetConnectionString("ServiceOrderDB")));
            #endregion
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