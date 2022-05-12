using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Core.Handlers.Request
{
    public class GetArticleQueryHandler : IRequestHandler<GetArticleQuery, GetArticleQueryResult>
    {
        public Task<GetArticleQueryResult> Handle(GetArticleQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
