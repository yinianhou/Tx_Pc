using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    /// <summary>
    /// 缓存帮助类
    /// </summary>
    public class CacheHelper
    {
        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <typeparam name="T">泛型类</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="cachePopulate">缓存委托</param>
        /// <param name="slidingExpiration">滑动过期时间</param>
        /// <param name="absoluteExpiration">固定过期时间</param>
        /// <returns>返回值</returns>
        public static T GetCacheItem<T>(string key, Func<T> cachePopulate, TimeSpan? slidingExpiration = null, DateTime? absoluteExpiration = null)
        {
            var cache = System.Web.HttpRuntime.Cache;
            var data = cache.Get(key);
            if (data == null)
            {
                var temp = cachePopulate();
                if (temp != null)
                {
                    var absolute = System.Web.Caching.Cache.NoAbsoluteExpiration;
                    if (absoluteExpiration.HasValue)
                    {
                        absolute = absoluteExpiration.Value;
                    }
                    var sliding = System.Web.Caching.Cache.NoSlidingExpiration;
                    if (slidingExpiration.HasValue)
                    {
                        sliding = slidingExpiration.Value;
                    }
                    cache.Insert(key, temp, null, absolute, sliding);
                    data = cache.Get(key);
                }
            }
            return (T)data;
        }

        /// <summary>
        /// 获取缓存对象(从内存中获取,用于winform或者wpf)
        /// </summary>
        /// <typeparam name="T">泛型类</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="cachePopulate">缓存委托</param>
        /// <param name="slidingExpiration">滑动过期时间</param>
        /// <param name="absoluteExpiration">固定过期时间</param>
        /// <returns>返回值</returns>
        public static T GetMemoryCacheItem<T>(string key, Func<T> cachePopulate, TimeSpan? slidingExpiration = null, DateTime? absoluteExpiration = null)
        {
            var cache = MemoryCache.Default;
            var data = cache[key];
            if (data == null)
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                var temp = cachePopulate();
                if (temp != null)
                {
                    Console.WriteLine("重新设置了");
                    if (absoluteExpiration.HasValue)
                    {
                        policy.AbsoluteExpiration = absoluteExpiration.Value;
                    }
                    else
                    {
                        policy.AbsoluteExpiration = System.Runtime.Caching.MemoryCache.InfiniteAbsoluteExpiration;
                    }
                    if (slidingExpiration.HasValue)
                    {
                        policy.SlidingExpiration = slidingExpiration.Value;
                    }
                    else
                    {
                        policy.SlidingExpiration = System.Runtime.Caching.MemoryCache.NoSlidingExpiration;
                    }
                    cache.Set(key, temp, policy);
                    data = cache[key] as string;
                }
                else
                {
                    Console.WriteLine("重新设置了依然没有数据，有点不应该");
                }
            }
            return (T)data;
        }
    }
}