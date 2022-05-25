using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shop.Infrastructure.ApiClients.Supplier1;
using Shop.Infrastructure.Interfaces;
using Shop.Infrastructure.Models;

namespace Shop.Infrastructure.ApiClients.Supplier2
{
    public class Supplier2ApiClient : IArticleRetriever
    {

        private readonly HttpClient _client;
        private readonly ILogger _logger;
        public Supplier2ApiClient(HttpClient client, ILogger<Supplier2ApiClient> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<GetArticleResponse> GetArticle(int id, CancellationToken token)
        {
                var response = await _client.SendAsync(new HttpRequestMessage(HttpMethod.Get, $"{_client.BaseAddress}/api/supplier/{id}"), token);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning($"Supplier2ApiClient failed during GetArticle({id}) call with status code : {response?.StatusCode}");
                    return null;
                }

                var result = await response.Content.ReadAsStringAsync();
                var article = JsonConvert.DeserializeObject<GetArticleResponse>(result);
               
                return article;
            
        }
    }
}