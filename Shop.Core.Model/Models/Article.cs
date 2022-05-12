using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Core.Model.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsSold { get; set; }
        public DateTime DateOfSale { get; set; }
        public int BuyerUserId { get; set; }
    }
}