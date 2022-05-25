namespace Shop.Core.Providers
{
    public class GetArticleProviderResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string SupplierName { get; set; }
    }
}
