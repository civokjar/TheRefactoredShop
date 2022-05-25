using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Core.Model.Models
{
    public class ArticlePurchase
    {
        public ArticlePurchase(Guid id, int articleId, decimal price, int buyerId) {

            Id = id;
            ArticleId = articleId;
            Price = price;
            BuyerUserId = buyerId;
        
        }
        public readonly Guid Id;
        public readonly int ArticleId;
        public readonly decimal Price;
        public readonly int BuyerUserId;
    }
}