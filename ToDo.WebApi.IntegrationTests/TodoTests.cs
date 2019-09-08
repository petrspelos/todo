using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(2, result.Length);
            Assert.Equal("Task 1", result[0].Description);
            Assert.False(result[0].IsCompleted);
            Assert.True(result[1].IsCompleted);
        }


        [Fact]
        public async Task AuthenticatedRequest_ShouldAddNewTask()
        {
            var testTodoTask = new TodoTask
            {
                Description = "Test 1"
            };

            var json = JsonConvert.SerializeObject(testTodoTask);

            SetupAuthenticatedClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/todo/add");
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task AuthenticatedRequest_ShouldRemoveTask()
        {
            SetupAuthenticatedClient();
            var json = JsonConvert.SerializeObject("76c4c3d2-757b-43d5-bce7-223c7d68db4a");

            var request = new HttpRequestMessage(HttpMethod.Delete, "/api/todo/remove");
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task AuthenticatedRequest_ShouldRemoveMany()
        {
            SetupAuthenticatedClient();
            var ids = new[] { "6328259d-07c7-4443-9973-9fac0404b9b2", "76c4c3d2-757b-43d5-bce7-223c7d68db4a" };
            var json = JsonConvert.SerializeObject(ids);

            var request = new HttpRequestMessage(HttpMethod.Delete, "/api/todo/removemany");
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            Assert.True(response.IsSuccessStatusCode);
        }

        private void SetupAuthenticatedClient() =>
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(
                    System.Text.Encoding.ASCII.GetBytes(
                        "User:Password")));
    }
}