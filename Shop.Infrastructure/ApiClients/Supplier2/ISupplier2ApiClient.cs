using Shop.Infrastructure.ApiClients.Supplier2.IO.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Infrastructure.ApiClients.Supplier2
{
    public interface ISupplier2ApiClient
    {
        Task<Supplier2GetArticleResponse> GetArticle(int id, CancellationToken token);
    }
}