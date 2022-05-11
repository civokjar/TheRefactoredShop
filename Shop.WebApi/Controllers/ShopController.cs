using System;
using System.Web.Http;
using Shop.WebApi.Models;
using Shop.WebApi.Services;

namespace Shop.WebApi.Controllers
{
    public class ShopController : ApiController
    {
        private Db Db;
        private Logger logger;

        private CachedSupplier CachedSupplier;
        private Warehouse Warehouse;
        private Dealer1 Dealer1;
        private Dealer2 Dealer2;

        public ShopController()
        {
            Db = new Db();
            logger = new Logger();
            CachedSupplier = new CachedSupplier();
            Warehouse = new Warehouse();
            Dealer1 = new Dealer1();
            Dealer2 = new Dealer2();
        }

        [HttpGet()]
        public Article GetArtice(int id, int maxExpectedPrice = 200)
        {
            Article article = null;
            Article tmp = null;
            var articleExists = CachedSupplier.ArticleInInventory(id);
            if (articleExists)
            {
                tmp = CachedSupplier.GetArticle(id);
                if (maxExpectedPrice < tmp.ArticlePrice)
                {
                    articleExists = Warehouse.ArticleInInventory(id);
                    if (articleExists)
                    {
                        tmp = Warehouse.GetArticle(id);
                        if (maxExpectedPrice < tmp.ArticlePrice)
                        {
                            articleExists = Dealer1.ArticleInInventory(id);
                            if (articleExists)
                            {
                                tmp = Dealer1.GetArticle(id);
                                if (maxExpectedPrice < tmp.ArticlePrice)
                                {
                                    articleExists = Dealer2.ArticleInInventory(id);
                                    if (articleExists)
                                    {
                                        tmp = Dealer2.GetArticle(id);
                                        if (maxExpectedPrice < tmp.ArticlePrice)
                                        {
                                            article = tmp;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (article != null)
                    {
                        CachedSupplier.SetArticle(article);
                    }
                }
            }

            return article;
        }

        [HttpPost]
        public void BuyArticle(Article article, int buyerId)
        {
            var id = article.ID;
            if (article == null)
            {
                throw new Exception("Could not order article");
            }

            logger.Debug("Trying to sell article with id=" + id);

            article.IsSold = true;
            article.SoldDate = DateTime.Now;
            article.BuyerUserId = buyerId;

            try
            {
                Db.Save(article);
                logger.Info("Article with id " + id + " is sold.");
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("Could not save article with id " + id);
                throw new Exception("Could not save article with id");
            }
            catch (Exception)
            {
            }
        }
    }
}