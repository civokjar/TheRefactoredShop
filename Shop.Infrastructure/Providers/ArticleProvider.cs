using AutoMapper;
using Shop.Core.Providers;
using Shop.Infrastructure.ApiClients.Supplier1;
using Shop.Infrastructure.ApiClients.Supplier2;
using Shop.Infrastructure.Interfaces;
using Shop.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Providers
{
    public class ArticleProvider : IArticleProvider
    {
        private readonly IEnumerable<IArticleRetriever> _articleRetrievers;
        private readonly IMapper _mapper;
        public ArticleProvider(IEnumerable<IArticleRetriever> articleRetrievers, IMapper mapper)
        {
            _articleRetrievers = articleRetrievers;
            _mapper = mapper;
        }
        public async Task<GetArticleProviderResponse> GetArticle(int id, int maxPrice, CancellationToken token)
        {
            foreach (var _retriever in _articleRetrievers)
            {
                var retrievedResponse = await _retriever.GetArticle(id, token);
                if (retrievedResponse?.ArticlePrice <= maxPrice)
                {
                    var response = _mapper.Map<GetArticleProviderResponse>(retrievedResponse);
                    response.SupplierName = _retriever.GetType().Name;
                    return response;
                }
            }
            return default(GetArticleProviderResponse);
        }

    }


}
