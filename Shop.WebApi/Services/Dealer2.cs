using System.Configuration;
using System.Net.Http;
using Newtonsoft.Json;
using Shop.WebApi.Models;

namespace Shop.WebApi.Services
{
    public class Dealer2
    {
        private readonly string _supplierUrl;

        public Dealer2()
        {
            _supplierUrl = ConfigurationManager.AppSettings["Dealer2Url"];
        }

        public bool ArticleInInventory(int id)
        {
            using (var client = new HttpClient())
            {
                var response = client.SendAsync(new HttpRequestMessage(HttpMethod.Get, $"{_supplierUrl}/Supplier/ArticleInInventory/{id}"));
                var hasArticle = JsonConvert.DeserializeObject<bool>(response.Result.Content.ReadAsStringAsync().Result);

                return hasArticle;
            }
        }

        public Article GetArticle(int id)
        {
            using (var client = new HttpClient())
            {
                var response = client.SendAsync(new HttpRequestMessage(HttpMethod.Get, $"{_supplierUrl}/Supplier/ArticleInInventory/{id}"));
                var article = JsonConvert.DeserializeObject<Article>(response.Result.Content.ReadAsStringAsync().Result);

                return article;
            }
        }
    }
}