using AutoMapper;
using Shop.Infrastructure.Interfaces;
using Shop.Infrastructure.Models;
using Shop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Services
{
    public class ArticleWarehouseService : IArticleRetriever
    {
        private readonly IMapper _mapper;
        private readonly IArticleWarehouseRepository _articleWarehouseRepository;
        public ArticleWarehouseService(IArticleWarehouseRepository articleWarehouseRepository, IMapper mapper) {

            _articleWarehouseRepository = articleWarehouseRepository;
            _mapper = mapper;
        }
        public async Task<GetArticleResponse> GetArticle(int id, CancellationToken token)
        {
            var response = await _articleWarehouseRepository.GetById(id, token);
            return _mapper.Map<GetArticleResponse>(response);
        }
    }
}
