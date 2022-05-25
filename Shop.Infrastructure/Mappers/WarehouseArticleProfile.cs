using AutoMapper;
using Shop.Core.Providers;
using Shop.Infrastructure.Models;

namespace Shop.Infrastructure.Mappers
{
    public class WarehouseArticleProfile : Profile
    {
        public WarehouseArticleProfile()
        {
            CreateMap<Core.Model.Models.Article, GetArticleResponse>()
                .ForMember(dest => dest.ArticlePrice, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Name_of_article, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id));
        }
    }
}
