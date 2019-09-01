using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace ToDo.WebApi.IntegrationTests
{
    public class AboutTests
    {
        private readonly HttpClient _client;
        private readonly TestServer _server;

        public AboutTests()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task GetRequest_ShouldReturnApplicationType()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/about");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Personal_ToDo_Application", content);
        }
    }
}
