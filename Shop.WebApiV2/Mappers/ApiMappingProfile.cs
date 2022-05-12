using AutoMapper;
using Shop.Core.Handlers.Command;
using Shop.Core.Handlers.Request;
using Shop.WebApiV2.IO.Responses;

namespace Shop.WebApiV2.Mappers
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<GetArticleQueryResult, GetArticleResponse>();
            CreateMap<BuyArticleCommandResult, BuyArticleResponse>();

        }
    }
}
