using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Site.Areas.admin.Controllers
{
    using System.Web.WebPages;
    using WebHelper;
    using Common;
    using IServices;
    using Model.ModelViews;
    using Model;
    using EntityMapping;
    public class roleController : BaseController
    {
        public roleController(IsysRoleServices rSer, IsysOrganStructServices oSer,IsysMenusServices mSer,IsysFunctionServices fSer,IsysPermissListServices pSer)
        {
            base.roleSer = rSer;
            base.organSer = oSer;
            base.menuSer = mSer;
            base.funSer = fSer;
            base.permissSer = pSer;
        }
        #region 列表
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 组织结构下的角色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult getlist(int id)
        {
            var list = roleSer.QueryWhere(c => c.eDepID == id).Select(c => new { c.rID,c.rName,c.rRemark,c.rStatus,c.rSort});
            return Json(new { Rows=list,Total=0});
        }
        [HttpPost, SkipcheckPermiss]
        public ActionResult getOrganTree()
        {
            try
            {
                var list = organSer.QueryWhere(c => c.osStatus == (int)Enums.EState.Normal).Select(c => new
                {
                    c.osID,
                    c.osParentID,
                    c.osName
                });
                return Json(list);
            }
            catch (Exception ex)
            { return WriteEroor(ex); }


           
        }
        #endregion
        #region 新增
        [HttpGet]
        public ActionResult add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult add(sysRoleView role)
        {
            return View();
        }
        #endregion
        #region 设置权限
        [HttpGet]
        public ActionResult setPermiss(int id)
        {
            ViewBag.rid = id;
            return View();
        }
        /// <summary>
        /// id代表角色id-菜单id,按钮id|菜单id,按钮id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult setPermiss()
        {
            try
            {
                string id = Request.Form["p"];
                string[] arr = id.Split('-');
                int rid = arr[0].AsInt();
                string[] permissrow = arr[1].Replace("m", "").Replace("f","").Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                ///先讲rid的旧权限删除
                permissSer.QueryWhere(c => c.rID == rid).ForEach(c => permissSer.Delete(c, true));
                //插入新权限
                string[] midfids;
                sysPermissList model;
                foreach (var midfid in permissrow)
                {
                    midfids = midfid.Split(',');
                    model = new sysPermissList
                    {
                        rID = rid,
                        mID = midfids[0].AsInt(),
                        fID = midfids[1].AsInt(),
                        plCreateTime = DateTime.Now,
                        plCreatorID = UserMgr.GetCurrentUserinfo().uID

                    };
                    //model追加到EF容器
                    permissSer.add(model);
                }
                //开启分布事物
                using (System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope())
                {
                    permissSer.SaveChanges();
                    scope.Complete();
                }
                return WriteSuccess("权限更新成功");
            }
            catch (Exception ex)
            {
                return WriteEroor(ex);
            }
        }
        /// <summary>
        /// id 代表当前角色id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, SkipcheckPermiss]
        public ActionResult getmftree(int id)
        {
            //从syspermisslist 获取该角色已拥有的权限
            var plist = permissSer.QueryWhere(c => c.rID == id);
            //获取sysMenus中数据
            var mlist = menuSer.QueryWhere(c => c.mStatus == (int)Enums.EState.Normal).Select(c => new { name=c.mName,id="m"+c.mID,pid="m"+c.mParentID,ischecked=plist.Any(p=>p.mID==c.mID),ismenu=true}).ToList();
            //获取sysfunction中数据
            var flist = funSer.QueryWhere(c => c.fStatus == (int)Enums.EState.Normal && c.fID > 5).Select(c => new { name = c.fName, id = "f" + c.fID, pid = "m" + c.mID, ischecked = plist.Any(p => p.fID == c.fID), ismenu = false }).ToList();
            mlist.AddRange(flist);
            return Json(mlist);
        }
        #endregion
    }
}
