using Article.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using System.Text.Json;
using System.Text;
using System.Net.Http.Json;

namespace Article.Client.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient httpClient;
        private readonly NavigationManager navigationManager;
        private readonly IConfiguration configuration;

        public HttpClientService(
            HttpClient httpClient,
            NavigationManager navigationManager,
            IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.navigationManager = navigationManager;
            this.configuration = configuration;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            return await SendRequestAsync<T>(request);
        }

        public async Task PutAsync(string uri, object value)
        {
            var request = CreateRequestAsync(HttpMethod.Put, uri, value);

            await SendRequestAsync(request);
        }

        private static HttpRequestMessage CreateRequestAsync(HttpMethod method, string uri, object value = null)
        {
            var request = new HttpRequestMessage(method, uri);

            if (value != null)
            {
                request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            }
            return request;
        }

        private async Task SendRequestAsync(HttpRequestMessage request)
        {
            using var response = await httpClient.SendAsync(request);
        }

        private async Task<T> SendRequestAsync<T>(HttpRequestMessage request)
        {
            using var response = await httpClient.SendAsync(request);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            //options.Converters.Add(new StringConverter());

            var result = await response.Content.ReadFromJsonAsync<T>(options);

            return result;
        }
    }
}
