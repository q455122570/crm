using CRM.WebHelper;
using System.Web;
using System.Web.Mvc;

namespace CRM.Site
{
    using CRM.WebHelper;
    public class FilterConfig
    {
        
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //将登录验证过滤器注册为全局过滤器，整个网站登录验证
            filters.Add(new CheckLoginAttrbute());
            //全局权限验证
            filters.Add(new CheckPermissAttribute());
        }
    }
}