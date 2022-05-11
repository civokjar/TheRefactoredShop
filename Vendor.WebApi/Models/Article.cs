using System;

namespace Vendor.WebApi.Models
{
    public class Article
    {
        public int ID { get; set; }

        public string Name_of_article { get; set; }

        public int ArticlePrice { get; set; }
        public bool IsSold { get; set; }

        public DateTime SoldDate { get; set; }
        public int BuyerUserId { get; set; }
    }
}