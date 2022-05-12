using Shop.Core.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Caching
{
    public partial class CacheService<T> : ICacheService<T>
    {
        public CacheService() { 
        
        
        }
        private static Dictionary<string, CacheItem<T>> Cache { get; set; } = new Dictionary<string, CacheItem<T>>();
        public void Store(string key, T value, TimeSpan expiresAfter)
        {
            lock (Cache)
            {
                var existing = Cache.ContainsKey(key);
                if (existing)
                {
                    Cache.Remove(key);
                }

                Cache.Add(key, new CacheItem<T>(value, expiresAfter));
            }
        }

        public T Get(string key)
        {
            lock (Cache)
            {
                var keyExists = Cache.ContainsKey(key);
                if (!keyExists || Cache[key].Created.AddSeconds(Cache[key].ExpiresAfter.TotalSeconds) < DateTime.Now)
                {
                    if (keyExists)
                       Remove(key);
                    return default(T);
                }
            }
            return Cache[key].Value;

        }
        private void Remove(string key)
        {
            Cache.Remove(key);
           
         
        }
    }
}
