using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Core.Providers
{
    public interface IArticleProvider
    {
        Task<GetArticleProviderResponse> GetArticle(int id, int maxPrice, CancellationToken token);
    }
}
