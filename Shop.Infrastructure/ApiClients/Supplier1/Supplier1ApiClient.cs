using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shop.Infrastructure.ApiClients.Supplier2;
using Shop.Infrastructure.Interfaces;
using Shop.Infrastructure.Models;

namespace Shop.Infrastructure.ApiClients.Supplier1
{
    public class Supplier1ApiClient : IArticleRetriever
    {
        private readonly string _supplierUrl;
        private readonly ILogger _logger;
        private const string _supplierName = nameof(Supplier1ApiClient);
        public Supplier1ApiClient(string supplierUrl, ILogger<Supplier1ApiClient> logger)
        {
            _supplierUrl = supplierUrl;
            _logger = logger;
}

        public async Task<GetArticleResponse> GetArticle(int id, CancellationToken token)
        {
            using (var client = new HttpClient())
            {
                var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, $"{_supplierUrl}/api/supplier/{id}"), token);
              
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning($"{_supplierName} failed during GetArticle({id}) call with status code : {response?.StatusCode}");
                    return null;
                }
                var result = await response.Content.ReadAsStringAsync();

                var article = JsonConvert.DeserializeObject<GetArticleResponse>(result);

                return article;
            }
        }
    }
}