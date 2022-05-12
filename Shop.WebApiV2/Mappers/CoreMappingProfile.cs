using AutoMapper;
using Shop.Core.Handlers.Request;
using Shop.WebApiV2.IO.Responses;

namespace Shop.WebApiV2.Mappers
{
    public class CoreMappingProfile : Profile
    {
        public CoreMappingProfile()
        {
            CreateMap<GetArticleQueryResult, GetArticleResponse>();
        }
    }
}
