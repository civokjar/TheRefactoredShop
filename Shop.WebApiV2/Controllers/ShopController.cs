using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.Core.Handlers.Request;
using Shop.WebApiV2.IO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.WebApiV2.Controllers
{
    [Route("Shop")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<ShopController> _logger;
        public ShopController(ILogger<ShopController> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [Route("Article/{id}")]
        [HttpGet]
        public async Task<GetArticleResponse> GetArticle([FromRoute] int id, [FromQuery] int maxPrice, CancellationToken token)
        {
            _logger.LogDebug("Trying to GetArtice with id=" + id);
            var coreResult = await _mediator.Send(new GetArticleQuery { Id = id, MaxPrice = maxPrice }, token);
            var response = _mapper.Map<GetArticleResponse>(coreResult);
            return response;
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
