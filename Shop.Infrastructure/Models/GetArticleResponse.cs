namespace Shop.Infrastructure.Models
{
    public class GetArticleResponse
    {
        public int ID { get; set; }

        public string Name_of_article { get; set; }

        public decimal ArticlePrice { get; set; }

        public string SupplierName { get; set; }
    }
}
