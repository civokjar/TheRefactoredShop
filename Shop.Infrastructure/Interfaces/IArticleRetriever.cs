using System.Threading.Tasks;
using System.Threading;
using Shop.Infrastructure.Models;

namespace Shop.Infrastructure.Interfaces
{
    public interface IArticleRetriever
    {
        Task<GetArticleResponse> GetArticle(int id, CancellationToken token);
    }
}