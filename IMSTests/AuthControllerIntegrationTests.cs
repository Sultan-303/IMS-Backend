using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IMS.API;
using IMS.BLL.DTOs.Auth;
using Newtonsoft.Json;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Azure.Core;

namespace IMSTests
{
    public class AuthControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AuthControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        private async Task<string> AuthenticateAsAdminAsync()
        {
            // Arrange
            var loginDto = new LoginDTO
            {
                Username = "admin", // Ensure this admin user exists
                Password = "Admin123!"
            };
            var content = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/auth/login", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Parse JSON to extract token
            dynamic result = JsonConvert.DeserializeObject(responseString);
            string token = result.token;

            // Assert
            Assert.False(string.IsNullOrEmpty(token), "Token should not be null or empty.");
            // status code 200
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            return token;
        }
    }
}