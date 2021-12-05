using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace RegisterLoginAPI
{
    /*
     * This class is necessary to run integrations tests simulating the project's initialization
     */

    public class StartupApiTest
    {
        public IConfiguration Configuration { get; }

        public StartupApiTest(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region MediatR

            //reference Handler in other class library
            var assembly = AppDomain.CurrentDomain.Load("Business");
            services.AddMediatR(assembly);

            #endregion MediatR
        }

        public void Configure(IApplicationBuilder app)
        {
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