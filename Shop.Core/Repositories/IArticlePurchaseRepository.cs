using Shop.Core.Model.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Core.Repositories
{
    public interface IArticlePurchaseRepository
    {
        Task<ArticlePurchase> GetById(Guid id, CancellationToken token);

        Task<bool> Save(int articleId, string name, int price, int buyerUserId, CancellationToken token);
    }
}
