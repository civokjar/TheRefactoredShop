using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.WebApiV2.IO.Requests
{
    public class GetArticleRequest
    {
        [FromRoute]
        [Required]
        public int? Id { get; set; }
        [FromQuery(Name = "MaxExpectedPrice")]
        [Required]
        public int? MaxExpectedPrice { get; set; } = 200;
    }
}