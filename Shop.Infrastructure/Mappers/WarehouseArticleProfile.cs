using AutoMapper;
using Shop.Core.Providers;

namespace Shop.Infrastructure.Mappers
{
    public class WarehouseArticleProfile : Profile
    {

        public WarehouseArticleProfile()
        {
            CreateMap<Core.Model.Models.Article, GetArticleProviderResponse>()
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => "Warehouse"));
        }
    }
}
