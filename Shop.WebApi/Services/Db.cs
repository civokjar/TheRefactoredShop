using System.Collections.Generic;
using System.Linq;
using Shop.WebApi.Models;

namespace Shop.WebApi.Services
{
    public class Db
    {
        private List<Article> _articles = new List<Article>();

        public Article GetById(int id)
        {
            return _articles.Single(x => x.ID == id);
        }

        public void Save(Article article)
        {
            _articles.Add(article);
        }
    }
}