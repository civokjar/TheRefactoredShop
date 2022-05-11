using System.Collections.Generic;
using System.Linq;
using Vendor.WebApi.Models;

namespace Vendor.WebApi.Services
{
    public class DatabaseDriver
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