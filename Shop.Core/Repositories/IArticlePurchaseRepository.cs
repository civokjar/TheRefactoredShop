using Shop.Core.Model.Models;
using System;
using System.Threading;

namespace Shop.Core.Repositories
{
    public interface IArticlePurchaseRepository
    {
        ArticlePurchase GetById(Guid id, CancellationToken token);

        void Save(int articleId, string name, int price, int buyerUserId, CancellationToken token);
    }
}
