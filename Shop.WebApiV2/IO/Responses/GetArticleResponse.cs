using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.WebApiV2.IO.Responses
{
    public class GetArticleResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}