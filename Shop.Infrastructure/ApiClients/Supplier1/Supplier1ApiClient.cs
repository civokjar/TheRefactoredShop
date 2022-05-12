using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shop.Infrastructure.ApiClients.Supplier1.IO.Responses;

namespace Shop.Infrastructure.ApiClients.Supplier1
{
    public class Supplier1ApiClient : ISupplier1ApiClient
    {
        private readonly string _supplierUrl;

        public Supplier1ApiClient(string supplierUrl)
        {
            _supplierUrl = supplierUrl;
}

        public async Task<Supplier1GetArticleResponse> GetArticle(int id, CancellationToken token)
        {
            using (var client = new HttpClient())
            {
                var response = client.SendAsync(new HttpRequestMessage(HttpMethod.Get, $"{_supplierUrl}/api/supplier/{id}"), token);

                if (!response.Result.IsSuccessStatusCode)
                    return null;

                var result = await response.Result.Content.ReadAsStringAsync();

                var article = JsonConvert.DeserializeObject<Supplier1GetArticleResponse>(result);

                return article;
            }
        }
    }
}