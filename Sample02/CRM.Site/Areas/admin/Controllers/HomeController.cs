using CRM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Site.Areas.admin.Controllers
{
    using System.Web.WebPages;
    using CRM.WebHelper;
    using Common;
    using IServices;
    using CRM.Model;
    using CRM.Model.ModelViews;
    using EntityMapping;
    [SkipcheckPermiss]
    public class HomeController : BaseController
    {
        public HomeController(IsysMenusServices mser)
        {
            base.menuSer=mser;
             
        }
        /// <summary>
        /// 获取菜单表的有效数据，并按排序号排序
        /// </summary>
        /// <returns></returns>
       

        //将数据以ViewBag.mlist传入视图

        public ActionResult Index()
        {
            //无权限控制
            // var list=menuSer.QueryOrderBy(c => c.mStatus == (int)Enums.EState.Normal, c => c.mSortid);
            //权限控制
            var list = menuSer.RunProc<sysMenus>("Usp_GetpermissMenusForUser "+UserMgr.GetCurrentUserinfo().uID);
            ViewBag.mlist = list;
            return View();
        }

    }
}
