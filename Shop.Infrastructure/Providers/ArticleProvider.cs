using AutoMapper;
using Shop.Core.Providers;
using Shop.Infrastructure.ApiClients.Supplier1;
using Shop.Infrastructure.ApiClients.Supplier2;
using Shop.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Providers
{
    public class ArticleProvider : IArticleProvider
    {
        private readonly ISupplier1ApiClient _supplier1ApiClient;
        private readonly ISupplier2ApiClient _supplier2ApiClient;
        private readonly IMapper _mapper;
        private readonly IArticleWarehouseRepository _articleWarehouseRepository;
        public ArticleProvider(ISupplier1ApiClient supplier1ApiClient, ISupplier2ApiClient supplier2ApiClient, IArticleWarehouseRepository articleWarehouseRepository, IMapper mapper)
        {
            _supplier1ApiClient = supplier1ApiClient;
            _supplier2ApiClient = supplier2ApiClient;
            _articleWarehouseRepository = articleWarehouseRepository; 
            _mapper = mapper;
        }
        public async Task<GetArticleProviderResponse> GetArticle(int id, int maxPrice, CancellationToken token)
        {
            // I guess I could create a factory or some generic implementation of this logic
            var warehouseResponse = await _articleWarehouseRepository.GetById(id, token);
            if (warehouseResponse?.Price <= maxPrice)
            {
                return _mapper.Map<GetArticleProviderResponse>(warehouseResponse);
            }
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
