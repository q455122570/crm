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
    public class functionController : BaseController
    {
        public functionController(IsysFunctionServices fSer,IsysMenusServices mSer)
        {
            base.funSer = fSer;
            base.menuSer = mSer;
        }
        //
        // GET: /admin/function/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult getlist(int id)
        {
            try
            {
                var list = funSer.QueryWhere(c => c.mID == id).Select(c => new
                {
                    c.fID,
                    c.fName,
                    c.fPicname,
                    c.fStatus
                });
                return Json(new { Rows = list, Total = 0 });
            }
            catch (Exception ex)
            {
                return WriteEroor(ex);
            }
        }
        /// <summary>
        /// 给ligertree提供数据
        /// </summary>
        /// <returns></returns>
        [HttpPost,SkipcheckPermiss]
        public ActionResult getMenusTree()
        {
            //查询sysmenu数据
            var list = menuSer.QueryWhere(c => c.mStatus == (int)Enums.EState.Normal).Select(c => new
            {
                c.mID,
                c.mParentID,
                c.mName
            });
            return Json(list);
 
        }

        #region 新增
        [HttpGet]
        public ActionResult add(int id)
        {
            base.SetStatus();
            return View();
 
        }
        [HttpPost]
        public ActionResult add(int id,sysFunctionView model)
        {
            try {
                if (ModelState.IsValid == false)
                {
                    return WriteEroor("实体验证失败");
                }
                model.mID = id;
                model.fUpdateTime = DateTime.Now;
                model.fCreateTime = DateTime.Now;
                model.fCreatorID = UserMgr.GetCurrentUserinfo().uID;

                var entity = model.EntityMap();
                funSer.add(entity);
                funSer.SaveChanges();
                
                
                return WriteSuccess("新增成功"); }
            catch (Exception ex) 
            { return WriteEroor(ex); }
           

        }
        #endregion
    }
}
