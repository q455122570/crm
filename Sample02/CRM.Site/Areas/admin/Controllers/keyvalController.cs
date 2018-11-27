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
    using Common;
    using IServices;
    using CRM.Model;
    using CRM.Model.ModelViews;
    using EntityMapping;
    [SkipcheckPermiss]
    public class keyvalController : BaseController
    {
        public keyvalController(IsysKeyValueServices kser) {
            base.keyvalSer = kser;
        }
        //
        // GET: /admin/keyval/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult getlist()
        {
            //先获取异步对象传入kname的值
            string kname=Request.Form["kname"];
            //根据kname值决定查询条件
            object list;
            if (kname.IsEmpty())
            {
                 list = keyvalSer.QueryOrderByDescending(c => true, c => c.KID).Select(c => new 
                { c.KID,c.KName,c.KType,c.Kvalue});
            }
            else
            {
                 list = keyvalSer.QueryOrderByDescending(c => c.KName.Contains(kname), c => c.KID).Select(c => new 
                { c.KID, c.KName, c.KType, c.Kvalue });
            }
            return Json(new { Rows = list,Total = 0 });
        }

        #region 新增
        [HttpGet]
        public ActionResult add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult add(sysKeyValueView model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return base.WriteEroor("实体验证失败");
                }
                //转化实体
                sysKeyValue entity = model.EntityMap();
                keyvalSer.add(entity);
                keyvalSer.SaveChanges();
                return base.WriteSuccess("新增成功");
            }
            catch(Exception ex) {
                return base.WriteEroor(ex);
 
            }
        }

        #endregion

        #region 编辑
        [HttpGet]
        public ActionResult edit(int id)
        {
            var model = keyvalSer.QueryWhere(c => c.KID == id).FirstOrDefault();

            //老数据传入视图
            return View(model.EntityMap());
        }
        [HttpPost]
        public ActionResult edit(int id,sysKeyValueView model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return WriteEroor("实体验证失败");
                }
                model.KID = id;

                sysKeyValue entity = model.EntityMap();
                keyvalSer.Edit(entity, new string[] { "KType", "KName", "Kvalue", "KRemark" });
                keyvalSer.SaveChanges();
                return WriteSuccess("数据编辑成功");
            }
            catch (Exception ex)
            {
                return WriteEroor(ex);
            }
        }
        #endregion

        #region 删除
        [HttpPost]
        public ActionResult del(string id)
        {
            try {
                string[] ids = id.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                sysKeyValue model;
                foreach (var kid in ids)
                {
                    model = new sysKeyValue() { KID = int.Parse(kid) };
                    keyvalSer.Delete(model, false);
 
                }
                keyvalSer.SaveChanges();
                return WriteSuccess("数据删除成功 ");
            }

            catch (Exception ex) 
            {
                return WriteEroor(ex); 
            }
 
        }
        #endregion
    }
}
