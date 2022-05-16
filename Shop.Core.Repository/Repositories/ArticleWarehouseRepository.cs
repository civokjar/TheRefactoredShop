using Shop.Core.Model.Models;
using Shop.Core.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Shop.Infrastructure.Repositories;

namespace Shop.Core.Repository.Repositories
{
    public class ArticleWarehouseRepository : IArticleWarehouseRepository
    {
        public async Task<Article> GetById(int id, CancellationToken token)
        {
            return  await Task.FromResult(new Article()
            {
                Id = id,
                Name = $"Article {id}",
                Price = new Random().Next(100, 500)
            });
        }
    }
}
