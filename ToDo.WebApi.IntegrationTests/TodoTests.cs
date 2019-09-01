using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using ToDo.Entities;
using ToDo.WebApi.Tests;
using Xunit;

namespace ToDo.WebApi.IntegrationTests
{
    public class TodoTests
    {
        private readonly HttpClient _client;
        private readonly TestServer _server;

        public TodoTests()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<TestStartup>());
            _client = _server.CreateClient();
        }

        [Theory]
        [InlineData("GET", "/api/todo/list")]
        [InlineData("POST", "/api/todo/add")]
        [InlineData("DELETE", "/api/todo/remove")]
        public async Task NotAuthenticatedRequests_ShouldGetUnauthorized(string method, string endpoint)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), endpoint);

            var response = await _client.SendAsync(request);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task AuthenticatedRequest_ShouldGetListOfTasks()
        {
            SetupAuthenticatedClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/todo/list");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TodoTask[]>(json);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Single(result);
            Assert.Equal("Todo task", result[0].Description);
        }

        private void SetupAuthenticatedClient() =>
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(
                    System.Text.Encoding.ASCII.GetBytes(
                        "User:Password")));
    }
}