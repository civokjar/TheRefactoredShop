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
        private List<Article> _articles = new List<Article>();

        public Article GetById(Guid id)
        {
            return _articles.Single(x => x.Id == id);
        }
        public void Save(string name, int price, int buyerUserId)
        {
            Guid guid = Guid.NewGuid();

            _articles.Add(new Article { Id = guid, BuyerUserId = buyerUserId });
        }

    }
}
