using AutoMapper;
using MediatR;
using Shop.Core.Caching;
using Shop.Core.Providers;
using Shop.Core.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Core.Handlers.Request
{
    public class GetArticleQueryHandler : IRequestHandler<GetArticleQuery, GetArticleQueryResult>
    {
     
        private readonly ICacheService<GetArticleQueryResult> _cacheService;
        private readonly IArticleProvider _articleProvider;
        private readonly IMapper _mapper;
        readonly string key = nameof(GetArticleQueryResult);
        public GetArticleQueryHandler(ICacheService<GetArticleQueryResult> cacheService, IArticleProvider articleProvider, IMapper mapper)
        {

            _cacheService = cacheService;
            _articleProvider = articleProvider;
            _mapper = mapper;


        }
        public async Task<GetArticleQueryResult> Handle(GetArticleQuery query, CancellationToken cancellationToken)
        {
            GetArticleQueryResult result = null;
            var cacheResponse = _cacheService.Get($"{key}{query.Id}");
            if (cacheResponse != null && cacheResponse.Price <= query.MaxPrice)
                return cacheResponse;

           
          
            var articleProviderResponse = await _articleProvider.GetArticle(query.Id, query.MaxPrice, cancellationToken);
            if(articleProviderResponse?.Price <= query.MaxPrice)
                result = _mapper.Map<GetArticleQueryResult>(articleProviderResponse);
     
            if(result != null)
                _cacheService.Store($"{key}{query.Id}", result, new TimeSpan(0, 0, Convert.ToInt32(120))); // Should be provided during DI
            
            return result;
        }
    }
}
