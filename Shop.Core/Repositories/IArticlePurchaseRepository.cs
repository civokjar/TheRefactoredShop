using Shop.Core.Model.Models;
using System;

namespace Shop.Core.Repositories
{
    public interface IArticlePurchaseRepository
    {
        ArticlePurchase GetById(Guid id);

        void Save(string name, int price, int buyerUserId);
    }
}
