using Shop.Core.Model.Models;
using System;
using System.Threading.Tasks;

namespace Shop.Repository.Repositories
{
    public interface IArticleWarehouseRepository
    {
        Task<Article> GetById(int id);

    }
}
