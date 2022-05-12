using AutoMapper;
using Shop.Core.Providers;
using Shop.Infrastructure.ApiClients.Supplier1;
using Shop.Infrastructure.ApiClients.Supplier2;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Providers
{
    public class ArticleProvider : IArticleProvider
    {
        private readonly ISupplier1ApiClient _supplier1ApiClient;
        private readonly ISupplier2ApiClient _supplier2ApiClient;
        private readonly IMapper _mapper;
        public ArticleProvider(ISupplier1ApiClient supplier1ApiClient, ISupplier2ApiClient supplier2ApiClient, IMapper mapper)
        {
            _supplier1ApiClient = supplier1ApiClient;
            _supplier2ApiClient = supplier2ApiClient;
            _mapper = mapper;
        }
        public async Task<GetArticleProviderResponse> GetArticle(int id, int maxPrice, CancellationToken token)
        {

            var supplier1ArticleResponse = await _supplier1ApiClient.GetArticle(id, token);
            if (supplier1ArticleResponse?.ArticlePrice <= maxPrice)
                return _mapper.Map<GetArticleProviderResponse>(supplier1ArticleResponse);

            var supplier2ArticleResponse = await _supplier2ApiClient.GetArticle(id, token);
            if (supplier2ArticleResponse?.ArticlePrice <= maxPrice)
                return _mapper.Map<GetArticleProviderResponse>(supplier2ArticleResponse);

            return default(GetArticleProviderResponse);
        }

    }


}
