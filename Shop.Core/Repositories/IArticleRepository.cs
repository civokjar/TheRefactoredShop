using Shop.Core.Model.Models;
using System;

namespace Shop.Repository.Repositories
{
    public interface IArticleWarehouseRepository
    {
        Article GetById(Guid id);

        void Save(string name, int price, int buyerUserId);
    }
}
