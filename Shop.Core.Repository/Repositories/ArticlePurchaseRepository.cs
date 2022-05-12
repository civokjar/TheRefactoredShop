using Shop.Core.Model.Models;
using Shop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Core.Repository.Repositories
{
    public class ArticlePurchaseRepository : IArticlePurchaseRepository
    {
        private List<ArticlePurchase> _articles = new List<ArticlePurchase>();

        public async Task<ArticlePurchase> GetById(Guid id, CancellationToken token)
        {
            return await Task.Run(async () => _articles.Single(x => x.Id == id)); // Just mimicking db call
        }
        public Task<bool> Save(int articleId, string name, int price, int buyerUserId, CancellationToken token)
        {
            Guid guid = Guid.NewGuid();

            _articles.Add(new ArticlePurchase { Id = guid, BuyerUserId = buyerUserId, Name = name, Price = price, ArticleId = articleId });
            return Task.FromResult(true);
            // Just mimicking db call
        }

    }
}
