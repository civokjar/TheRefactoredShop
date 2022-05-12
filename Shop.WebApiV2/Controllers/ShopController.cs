using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Shop.Core.Handlers.Command;
using Shop.Core.Handlers.Request;
using Shop.WebApiV2.IO.Requests;
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
        public async Task<GetArticleResponse> GetArticle(GetArticleRequest request, CancellationToken token)
        {
            _logger.LogDebug($"Trying to GetArtice with id = {request.Id}");
            var coreResult = await _mediator.Send(new GetArticleQuery { Id = request.Id, MaxPrice = request.MaxExpectedPrice }, token);
            var response = _mapper.Map<GetArticleResponse>(coreResult);
            return response;
        }
        [Route("Article/{id}/Buy")]
        [HttpPost]
        [ProducesResponseType(typeof(BuyArticleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> BuyArticle([FromRoute] int id, int buyerId, CancellationToken token)
        {
            _logger.LogDebug($"Trying to GetArtice with id = {id}");
            var coreResult = await _mediator.Send(new BuyArticleCommand { Id = id, BuyerId = buyerId }, token);
            var response = _mapper.Map<BuyArticleResponse>(coreResult);

            if (response == null)
                return NoContent();
            
            return Ok(response);
        }
    }
}
