using AutoMapper;
using Shop.Core.Providers;
using Shop.Infrastructure.ApiClients.Supplier1.IO.Responses;
using Shop.Infrastructure.ApiClients.Supplier2.IO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Mappers
{
    public class Supplier1ApiClientProfile : Profile
    {

        public Supplier1ApiClientProfile()
        {
            CreateMap<Supplier1GetArticleResponse, GetArticleProviderResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name_of_article))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(source => source.ArticlePrice))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.ID));
        }
    }
}
