using RegisterLoginAPI;
using System;
using System.Net.Http;
using Xunit;

namespace Test.Integration.Configs
{
    /*
     This class allows us to create an interaction with the StartupApiTest class and thus generate calls to the integration test methods
     */

    [CollectionDefinition(nameof(IntegrationApiTestFixtureCollection))]
    public class IntegrationApiTestFixtureCollection :
       ICollectionFixture<IntegrationTestFixture<StartupApiTest>>
    { }

    public class IntegrationTestFixture<TStartup> : IDisposable where TStartup : class
    {
        public readonly RegisterLoginAppFactory<TStartup> Factory;
        public HttpClient Client;

        public IntegrationTestFixture()
        {
            var clientOptions = new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions
            {
                HandleCookies = false,
                BaseAddress = new Uri("https://localhost:44334"),
                AllowAutoRedirect = true,
                MaxAutomaticRedirections = 7
            };

            Factory = new RegisterLoginAppFactory<TStartup>();
            Client = Factory.CreateClient(clientOptions);
        }

        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }
    }
}