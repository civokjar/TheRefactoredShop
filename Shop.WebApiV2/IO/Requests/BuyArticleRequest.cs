using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Shop.WebApiV2.IO.Requests
{
    public class BuyArticleRequest
    {
        [FromRoute]
        [Required]
        public int Id { get; set; }
        [FromBody]
        [Required]
        public int BuyerId { get; set; }
    }
}