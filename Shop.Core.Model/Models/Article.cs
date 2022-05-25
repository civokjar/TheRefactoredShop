using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Core.Model.Models
{
    public class Article
    {
        public Article(int id, string name, decimal price)
        {

            Id = id;
            Name = name;
            Price = price;
        }
        public readonly int Id;
        public readonly string Name;
        public readonly decimal Price;
    }
}