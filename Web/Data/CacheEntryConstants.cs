using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Data
{
    /// <summary>
    /// 存放缓存的Key
    /// </summary>
    public class CacheEntryConstants
    {
        /// <summary>
        /// HomeController里面的TestMemoryCache
        /// </summary>
        public const string TestMemoryCache = nameof(TestMemoryCache);

        /// <summary>
        /// MovieController里面的获取MovieList的Index方法
        /// </summary>
        public const string MovieList = nameof(MovieList);
         
    }
}
