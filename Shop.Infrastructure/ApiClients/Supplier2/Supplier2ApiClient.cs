using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shop.Infrastructure.Interfaces;
using Shop.Infrastructure.Models;

namespace Shop.Infrastructure.ApiClients.Supplier2
{
    public class Supplier2ApiClient : IArticleRetriever
    {
        private readonly string _supplierUrl;
        private const string _supplierName = nameof(Supplier2ApiClient);
        private readonly ILogger _logger;
        public Supplier2ApiClient(string supplierUrl, ILogger logger)
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