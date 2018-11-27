using CRM.WebHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Site.Areas.admin.Controllers
{
    using System.Web.WebPages;
    using CRM.WebHelper;
    using CRM.Common;
    using IServices;
    using CRM.Model;
    using CRM.Model.ModelViews;
    using EntityMapping;
    [SkipcheckPermiss]
    public class PermissOptController : BaseController
    {
        public PermissOptController(IsysPermissListServices pSer)
        {
            base.permissSer = pSer;
        }
        //
        // GET: /admin/PermissOpt/
        /// <summary>
        /// 获取当前登录用户的所在菜单权限按钮
        /// </summary>
        /// <returns></returns>
        public ActionResult getFunctions()
        {
            //获取用户id
            int uid = UserMgr.GetCurrentUserinfo().uID;
            //获取当前页面传入的url
            string url = Request.Form["murl"];

            //根据url从当前用户的权限按钮缓存数据中获取指定的按钮
            var allFunctionsFromCache = permissSer.GetFunctionsForUserByCache(uid);
            var functions = allFunctionsFromCache.Where(c => c.mUrl.ToLower() == url.ToLower());
            //遍历 拼接成json格式,liger中的toolbaritem格式
            System.Text.StringBuilder resJson = new System.Text.StringBuilder("[", 200);
            if (functions.Any())
            {
                foreach (var item in functions)
                {
                    //resJson.Append("{\"text\":\"" + item.fName + "\", \"click\":\"" + item.fFunction + "\" , \"icon\": \""+item.fPicname+"\"},{line:true},");
                    resJson.Append("{ \"text\": \"" + item.fName + "\", \"click\": \"" + item.fFunction + "\", \"icon\": \"" + item.fPicname + "\" }, { \"line\": \"true\" },");
                }

                //最后一个,移除
                if (resJson.Length > 1)
                {
                    resJson.Remove(resJson.Length - 1, 1);
                }
                resJson.Append("]");
            }
            //
            return Content(resJson.ToString());
        }

    }
}
