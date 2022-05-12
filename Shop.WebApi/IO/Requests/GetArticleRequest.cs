using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.WebApi.IO.Requests
{
    public class GetArticleRequest
    {
        public int Id { get; set; }
        public int MaxExpectedPrice { get; set; }
    }
}