using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Common
{
    using System.Web;
    //缓存管理
    public class CacheMgr
    {
        public static T GetData<T>(string cacheKey)
        {
            return (T)HttpRuntime.Cache[cacheKey];
        }
        public static void SetData(string cacheKey, object val)
        {
            HttpRuntime.Cache[cacheKey] = val;
        }
    }
}
