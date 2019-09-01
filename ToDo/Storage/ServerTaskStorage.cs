using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ToDo.Entities;

namespace ToDo.Storage
{
    public class ServerTaskStorage : ITaskStorage
    {
        private readonly HttpClient _client;
        private readonly string _server;

        public ServerTaskStorage(HttpClient client, string username, string password, string server)
        {
            _client = client;
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(
                    System.Text.Encoding.ASCII.GetBytes(
                        $"{username}:{password}")));
            _server = server;
        }

        public async Task Store(TodoTask task)
        {
            var json = JsonConvert.SerializeObject(task);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{_server}/api/todo/add", content);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Server responded with a non-OK status code.");
            }
        }

        public async Task<TodoTask[]> RetrieveAll()
        {
            var response = await _client.GetAsync($"{_server}/api/todo/list");

            var json = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Server responded with a non-OK status code.");
            }

            return JsonConvert.DeserializeObject<TodoTask[]>(json);
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
