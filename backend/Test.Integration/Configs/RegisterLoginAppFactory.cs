using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Test.Integration.Configs
{
    public class RegisterLoginAppFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class

    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseStartup<TStartup>();
            builder.UseEnvironment("Development");
        }
    }
}