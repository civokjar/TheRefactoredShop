﻿using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shop.Infrastructure.ApiClients.Supplier1.IO.Responses;
using Shop.Infrastructure.ApiClients.Supplier2.IO.Responses;

namespace Shop.Infrastructure.ApiClients.Supplier2
{
    public class Supplier2ApiClient : ISupplier2ApiClient
    {
        private readonly string _supplierUrl;

        public Supplier2ApiClient(string supplierUrl)
        {
            _supplierUrl = supplierUrl;
        }

        public async Task<Supplier2GetArticleResponse> GetArticle(int id, CancellationToken token)
        {
            using (var client = new HttpClient())
            {
                var response = client.SendAsync(new HttpRequestMessage(HttpMethod.Get, $"{_supplierUrl}/api/supplier/{id}"), token);

                if (!response.Result.IsSuccessStatusCode)
                    return null;

                var result = await response.Result.Content.ReadAsStringAsync();
                var article = JsonConvert.DeserializeObject<Supplier2GetArticleResponse>(result);

                return article;
            }
        }
    }
}