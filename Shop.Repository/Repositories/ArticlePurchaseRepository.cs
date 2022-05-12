using Shop.Core.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repository.Repositories
{
    public class ArticlePurchaseRepository
    {
        private List<ArticlePurchase> _articles = new List<ArticlePurchase>();

        public ArticlePurchase GetById(Guid id)
        {
            return _articles.Single(x => x.Id == id);
        }
        public void Save(int articleId, string name, int price, int buyerUserId)
        {
            Guid guid = Guid.NewGuid();

            _articles.Add(new ArticlePurchase { Id = guid, BuyerUserId = buyerUserId, Name = name, Price = price, ArticleId = articleId });
        }

    }
}
