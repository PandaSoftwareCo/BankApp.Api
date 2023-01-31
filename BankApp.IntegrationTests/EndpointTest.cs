using BankApp.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Security.Policy;

namespace BankApp.IntegrationTests
{
    public class EndpointTest
    {
        private HttpClient _client;

        public EndpointTest()
        {
            var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                //builder
                //    .UseTestServer()
                //    .ConfigureServices(services =>
                //    {
                //        services.AddMyServices();
                //    })
                //    .Configure(app =>
                //    {
                //        app.UseMiddleware<MyMiddleware>();
                //    });
            });
            _client = application.CreateClient();
        }

        [Fact]
        public async Task CheckHealth()
        {
            var response = await _client.GetAsync("/health");

            response.EnsureSuccessStatusCode();
            Assert.NotEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal("text/plain", response.Content.Headers?.ContentType?.ToString());
            var message = await response.Content.ReadAsStringAsync();
            Assert.Equal("Healthy", message);
        }

        [Theory]
        [InlineData("api/v1/Accounts")]
        [InlineData("api/v1/Balances")]
        [InlineData("api/v1/BankTransactions")]
        [InlineData("api/v1/Categories")]
        [InlineData("api/v1/Mileage")]
        [InlineData("api/v1/Vehicle")]
        public async Task Get_EndpointReturns(string url)
        {
            var response = await _client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8; v=1", response.Content.Headers?.ContentType?.ToString());
        }
    }
}