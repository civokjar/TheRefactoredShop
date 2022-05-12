namespace Shop.Infrastructure.ApiClients.Supplier1.IO.Responses
{
    public class Supplier1GetArticleResponse
    {
        public int ID { get; set; }

        public string Name_of_article { get; set; }

        public int ArticlePrice { get; set; }

        public readonly string SupplierName = "Supplier1";
    }
}
