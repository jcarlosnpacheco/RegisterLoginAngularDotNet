using Business.Commands.Generics;
using Business.Models;
using Newtonsoft.Json;
using RegisterLoginAPI;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Test.Integration.Configs;
using Xunit;

namespace Test.Integration
{
    [Collection(nameof(IntegrationApiTestFixtureCollection))]
    public class LoginTypeFixturesTest
    {
        private readonly IntegrationTestFixture<StartupApiTest> _integrationTestFixture;
        private const string API_URL_LOGIN_TYPE = "/api/LoginType";

        public LoginTypeFixturesTest(IntegrationTestFixture<StartupApiTest> integrationTestFixture)
        {
            _integrationTestFixture = integrationTestFixture;
        }

        [Fact(DisplayName = "Get Login's Type"), TestPriority(2)]
        public async Task Get_All_Login_Type()
        {
            // Arrange
            var request = await _integrationTestFixture.Client.GetAsync($"{API_URL_LOGIN_TYPE}");

            // Act
            await request.Content.ReadAsStringAsync();

            // Assert
            Assert.True(request.IsSuccessStatusCode);
        }

        [Fact(DisplayName = "Post Login's Type"), TestPriority(1)]
        public async Task Post_Login_Type()
        {
            // Arrange
            var data = new
            {
                Url = API_URL_LOGIN_TYPE,
                Body = new
                {
                    Name = "Name of login_type integration test"
                }
            };

            var formattedContent = new StringContent(JsonConvert.SerializeObject(data.Body), Encoding.Default, "application/json");

            var request = await _integrationTestFixture.Client.PostAsync(
                API_URL_LOGIN_TYPE,
                formattedContent);

            var response = await request.Content.ReadAsStringAsync();
            var genericCommandResult = JsonConvert.DeserializeObject<GenericCommandResult>(response);

            //Assert
            Assert.True(request.IsSuccessStatusCode);
            Assert.True(genericCommandResult.Success);
            Assert.NotNull(genericCommandResult.Data);
        }

        [Fact(DisplayName = "Put Login's Type"), TestPriority(3)]
        public async Task Put_Login_Type()
        {
            // Arrange
            var requestAllLoginTypeRecords = await _integrationTestFixture.Client.GetAsync($"{API_URL_LOGIN_TYPE}");
            var responseAllLoginTypeRecords = await requestAllLoginTypeRecords.Content.ReadAsStringAsync();
            var listOfLoginType = JsonConvert.DeserializeObject<IEnumerable<LoginTypeModel>>(responseAllLoginTypeRecords);
            var getLoginType = listOfLoginType
                               .FirstOrDefault(l => l.Name.Contains("login_type integration test"));

            var data = new
            {
                Url = API_URL_LOGIN_TYPE,
                Body = new
                {
                    Id = getLoginType.Id,
                    Name = $"updated { getLoginType.Name }"
                }
            };

            var formattedContent = new StringContent(JsonConvert.SerializeObject(data.Body), Encoding.Default, "application/json");

            var request = await _integrationTestFixture.Client.PutAsync(
                API_URL_LOGIN_TYPE,
                formattedContent);

            var response = await request.Content.ReadAsStringAsync();
            var genericCommandResult = JsonConvert.DeserializeObject<GenericCommandResult>(response);

            //Assert
            Assert.True(request.IsSuccessStatusCode);
            Assert.True(genericCommandResult.Success);
            Assert.NotNull(genericCommandResult.Data);
        }

        [Fact(DisplayName = "Delete Login's Type"), TestPriority(4)]
        public async Task Delete_Login_Type()
        {
            // Arrange
            var requestAllLoginTypeRecords = await _integrationTestFixture.Client.GetAsync($"{API_URL_LOGIN_TYPE}");
            var responseAllLoginTypeRecords = await requestAllLoginTypeRecords.Content.ReadAsStringAsync();
            var listOfLoginType = JsonConvert.DeserializeObject<IEnumerable<LoginTypeModel>>(responseAllLoginTypeRecords);
            var getLoginTypeToRemove = listOfLoginType
                               .FirstOrDefault(l => l.Name.Contains("login_type integration test"));

            var request = await _integrationTestFixture.Client.DeleteAsync(
                $"{API_URL_LOGIN_TYPE}/{getLoginTypeToRemove.Id}");

            var response = await request.Content.ReadAsStringAsync();
            var genericCommandResult = JsonConvert.DeserializeObject<GenericCommandResult>(response);

            //Assert
            Assert.Equal("Successfully deleted", genericCommandResult.Message);
        }
    }
}