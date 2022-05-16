using System.Threading.Tasks;
using Shop.Core.Model.Models;
using System.Threading;

namespace Shop.Infrastructure.Repositories
{
    public interface IArticleWarehouseRepository
    {
        Task<Article> GetById(int id, CancellationToken token);
    }
}
