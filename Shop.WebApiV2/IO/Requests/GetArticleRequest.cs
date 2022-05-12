using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.WebApiV2.IO.Requests
{
    public class GetArticleRequest
    {
        public int Id { get; set; }
        public int MaxExpectedPrice { get; set; }
    }
}