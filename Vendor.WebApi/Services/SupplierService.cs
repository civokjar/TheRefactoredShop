using System;
using Vendor.WebApi.Models;

namespace Vendor.WebApi.Services
{
    public class SupplierService
    {
        public bool ArticleInInventory(int id)
        {
            return new Random().NextDouble() >= 0.5;
        }

        public Article GetArticle(int id)
        {
            return new Article()
            {
                ID = id,
                Name_of_article = $"Article {id}",
                ArticlePrice = new Random().Next(100,500)
            };
        }
    }
}