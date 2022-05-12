using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shop.Infrastructure.ApiClients.Supplier1;
using Shop.Infrastructure.ApiClients.Supplier1.IO.Responses;
using Shop.Infrastructure.ApiClients.Supplier2.IO.Responses;

namespace Shop.Infrastructure.ApiClients.Supplier2
{
    public class Supplier2ApiClient : ISupplier2ApiClient
    {
        private readonly string _supplierUrl;
        private const string _supplierName = nameof(Supplier2ApiClient);
        private readonly ILogger _logger;
        public Supplier2ApiClient(string supplierUrl, ILogger<Supplier2ApiClient> logger)
        {
            _supplierUrl = supplierUrl;
            _logger = logger;
        }

        public async Task<Supplier2GetArticleResponse> GetArticle(int id, CancellationToken token)
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
                var article = JsonConvert.DeserializeObject<Supplier2GetArticleResponse>(result);
               
                return article;
            }
        }
    }
}