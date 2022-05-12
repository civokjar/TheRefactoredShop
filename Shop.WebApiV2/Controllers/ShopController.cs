using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.WebApiV2.IO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.WebApiV2.Controllers
{
    [Route("Shop")]
    [ApiController]
    public class ShopController : ControllerBase
    {

        public ShopController()
        {
        }

        [Route("Article/{id}")]
        [HttpGet]
        public GetArticleResponse GetArtice([FromRoute] int id)
        {
            GetArticleResponse article = null;
            GetArticleResponse tmp = null;
            //var articleExists = CachedSupplier.ArticleInInventory(id);
            //if (articleExists)
            //{
            //    tmp = CachedSupplier.GetArticle(id);
            //    if (maxExpectedPrice < tmp.Price)
            //    {
            //        articleExists = Warehouse.ArticleInInventory(id);
            //        if (articleExists)
            //        {
            //            tmp = Warehouse.GetArticle(id);
            //            if (maxExpectedPrice < tmp.Price)
            //            {
            //                articleExists = Dealer1.ArticleInInventory(id);
            //                if (articleExists)
            //                {
            //                    tmp = Dealer1.GetArticle(id);
            //                    if (maxExpectedPrice < tmp.Price)
            //                    {
            //                        articleExists = Dealer2.ArticleInInventory(id);
            //                        if (articleExists)
            //                        {
            //                            tmp = Dealer2.GetArticle(id);
            //                            if (maxExpectedPrice < tmp.Price)
            //                            {
            //                                article = tmp;
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //        if (article != null)
            //        {
            //            CachedSupplier.SetArticle(article);
            //        }
            //    }
            //}

            return article;
        }

        //[HttpPost]
        //public void BuyArticle(Article article, int buyerId)
        //{
        //    var id = article.Id;
        //    if (article == null)
        //    {
        //        throw new Exception("Could not order article");
        //    }

        //    logger.Debug("Trying to sell article with id=" + id);

        //    //article.IsSold = true;
        //    //article.DateOfSale = DateTime.Now;
        //    //article.BuyerUserId = buyerId;

        //    try
        //    {
        //        Db.Save(article);
        //        logger.Info("Article with id " + id + " is sold.");
        //    }
        //    catch (ArgumentNullException ex)
        //    {
        //        logger.Error("Could not save article with id " + id);
        //        throw new Exception("Could not save article with id");
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}
    }
}
