using Shop.Core.Model.Models;
using Shop.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Repository.Repositories
{
    public class ArticleWarehouseRepository : IArticleWarehouseRepository
    {
        public async Task<Article> GetById(int id)
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
