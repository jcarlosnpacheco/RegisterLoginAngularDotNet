using Business.Commands.Generics;
using Newtonsoft.Json;
using RegisterLoginAPI;
using RegisterLoginAPI.Business.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Test.Integration.Configs;
using Xunit;

namespace Test.Integration
{
    [TestCaseOrderer("Test.Configs.AlphabeticalOrderer", "Test.Integration")]
    [Collection(nameof(IntegrationApiTestFixtureCollection))]
    public class RegisterLoginFixturesTest
    {
        private readonly IntegrationTestFixture<StartupApiTest> _integrationTestFixture;
        private const string API_URL_REGISTER_LOGIN = "/api/RegisterLogin";

        public RegisterLoginFixturesTest(IntegrationTestFixture<StartupApiTest> integrationTestFixture)
        {
            _integrationTestFixture = integrationTestFixture;
        }

        [Fact(DisplayName = "1 - Get All Login's Registers")]
        public async Task Test1_Get_All_Register_Login()
        {
            // Arrange
            var request = await _integrationTestFixture.Client.GetAsync($"{API_URL_REGISTER_LOGIN}");

            // Act
            await request.Content.ReadAsStringAsync();

            // Assert
            Assert.True(request.IsSuccessStatusCode);
        }

        [Fact(DisplayName = "2 - Post Login's Register")]
        public async Task Test2_Post_Register_Login()
        {
            // Arrange
            var data = new
            {
                Url = API_URL_REGISTER_LOGIN,
                Body = new
                {
                    LoginName = "LoginName Test",
                    Password = "123456",
                    Observation = "Observation Test",
                    LoginTypeId = 1,
                }
            };

            var formattedContent = new StringContent(JsonConvert.SerializeObject(data.Body), Encoding.Default, "application/json");

            var request = await _integrationTestFixture.Client.PostAsync(
                API_URL_REGISTER_LOGIN,
                formattedContent);

            var response = await request.Content.ReadAsStringAsync();
            var genericCommandResult = JsonConvert.DeserializeObject<GenericCommandResult>(response);

            //Assert
            Assert.True(request.IsSuccessStatusCode);
            Assert.True(genericCommandResult.Success);
            Assert.NotNull(genericCommandResult.Data);
        }

        [Fact(DisplayName = "3 - Put Login's Register")]
        public async Task Test3_Put_Register_Login()
        {
            // Arrange
            var requestAllRecords = await _integrationTestFixture.Client.GetAsync($"{API_URL_REGISTER_LOGIN}");
            var responseAllRecords = await requestAllRecords.Content.ReadAsStringAsync();
            var listOfRegisterLogin = JsonConvert.DeserializeObject<IEnumerable<RegisterLoginModel>>(responseAllRecords);
            var getRegisterLogin = listOfRegisterLogin
                               .FirstOrDefault(l => l.LoginName.Contains("LoginName Test"));

            var data = new
            {
                Url = API_URL_REGISTER_LOGIN,
                Body = new
                {
                    Id = getRegisterLogin.Id,
                    LoginName = $"updated { getRegisterLogin.LoginName }",
                    Password = $"updated { getRegisterLogin.Password }",
                    Observation = $"updated { getRegisterLogin.Observation }",
                    LoginTypeId = 1,
                }
            };

            var formattedContent = new StringContent(JsonConvert.SerializeObject(data.Body), Encoding.Default, "application/json");

            var request = await _integrationTestFixture.Client.PutAsync(
                API_URL_REGISTER_LOGIN,
                formattedContent);

            var response = await request.Content.ReadAsStringAsync();
            var genericCommandResult = JsonConvert.DeserializeObject<GenericCommandResult>(response);

            //Assert
            Assert.True(request.IsSuccessStatusCode);
            Assert.True(genericCommandResult.Success);
            Assert.NotNull(genericCommandResult.Data);
        }

        [Fact(DisplayName = "4 - Delete Login's Register")]
        public async Task Test4_Delete_Register_Login()
        {
            // Arrange
            var requestAllLoginTypeRecords = await _integrationTestFixture.Client.GetAsync($"{API_URL_REGISTER_LOGIN}");
            var responseAllLoginTypeRecords = await requestAllLoginTypeRecords.Content.ReadAsStringAsync();
            var listOfRegisterLogin = JsonConvert.DeserializeObject<IEnumerable<RegisterLoginModel>>(responseAllLoginTypeRecords);
            var getRegisterLoginToRemove = listOfRegisterLogin
                               .FirstOrDefault(l => l.LoginName.Contains("LoginName Test"));

            var request = await _integrationTestFixture.Client.DeleteAsync(
                $"{API_URL_REGISTER_LOGIN}/{getRegisterLoginToRemove.Id}");

            var response = await request.Content.ReadAsStringAsync();
            var genericCommandResult = JsonConvert.DeserializeObject<GenericCommandResult>(response);

            //Assert
            Assert.Equal("Successfully deleted", genericCommandResult.Message);
        }
    }
}