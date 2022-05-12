using Shop.Core.Model.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Core.Repositories
{
    public interface IArticleWarehouseRepository
    {
        Task<Article> GetById(int id, CancellationToken token);

    }
}
