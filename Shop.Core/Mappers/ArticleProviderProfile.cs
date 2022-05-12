using AutoMapper;
using Shop.Core.Handlers.Request;
using Shop.Core.Model.Models;
using Shop.Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Mappers
{
    public class ArticleProviderProfile : Profile
    {

        public ArticleProviderProfile()
        {
            CreateMap<GetArticleProviderResponse, GetArticleQueryResult>();
            CreateMap<Article, GetArticleQueryResult>();
        }
    }
}
