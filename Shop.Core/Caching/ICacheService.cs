using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Caching
{
    public interface ICacheService<T>
    {
        public void Store(string key, T value, TimeSpan expiresAfter);
        public T Get(string key);
    }
}
