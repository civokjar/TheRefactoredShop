namespace Shop.Infrastructure.ApiClients.Supplier2.IO.Responses
{
    public class Supplier2GetArticleResponse
    {
        public int ID { get; set; }

        public string Name_of_article { get; set; }

        public int ArticlePrice { get; set; }

        public readonly string SupplierName = "Supplier2";
    }
}
