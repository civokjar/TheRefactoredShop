using AutoMapper;
using Shop.Core.Providers;
using Shop.Infrastructure.ApiClients.Supplier1.IO.Responses;
using Shop.Infrastructure.ApiClients.Supplier2.IO.Responses;

namespace Shop.Infrastructure.Mappers 
{
    public class Supplier2ApiClientProfile : Profile
    {
        public Supplier2ApiClientProfile()
        {
            CreateMap<Supplier2GetArticleResponse, GetArticleProviderResponse>()
              .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name_of_article))
              .ForMember(dest => dest.Price, opt => opt.MapFrom(source => source.ArticlePrice))
              .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.ID));
        }
    }
}
