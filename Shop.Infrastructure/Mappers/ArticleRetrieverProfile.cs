using AutoMapper;
using Shop.Core.Providers;
using Shop.Infrastructure.Models;

namespace Shop.Infrastructure.Mappers
{
    public class ArticleRetrieverProfile : Profile
    {
        public ArticleRetrieverProfile()
        {
            CreateMap<GetArticleResponse, GetArticleProviderResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name_of_article))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(source => source.ArticlePrice))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.ID));
        }
    }
}
