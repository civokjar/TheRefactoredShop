using Shop.Infrastructure.ApiClients.Supplier1.IO.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Infrastructure.ApiClients.Supplier1
{
    public interface ISupplier1ApiClient
    {
        Task<Supplier1GetArticleResponse> GetArticle(int id, CancellationToken token);
    }
}