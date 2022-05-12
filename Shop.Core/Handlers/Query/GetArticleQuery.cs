using MediatR;

namespace Shop.Core.Handlers.Request
{
    public class GetArticleQuery : IRequest<GetArticleQueryResult>
    {
        public int Id { get; set; }

        public int MaxPrice { get; set; }
    }
}
