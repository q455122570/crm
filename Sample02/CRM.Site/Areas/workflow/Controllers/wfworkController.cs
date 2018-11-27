using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Site.Areas.workflow.Controllers
{
    using System.Web.WebPages;
    using CRM.WebHelper;
    using Common;
    using IServices;
    using CRM.Model;
    using CRM.Model.ModelViews;
    using EntityMapping;
    public class wfworkController : BaseController
    {
        public wfworkController(IwfWorkServices wSer,IwfWorkNodesServices nSer,IsysKeyValueServices kSer)
        {
            base.workSer = wSer;
            base.worknodesSer = nSer;
            base.keyvalSer = kSer;
        }
        //
        // GET: /workflow/wfwork/
        #region 列表
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult getlist()
        {
            var list=workSer.QueryWhere(c => true).Select(c => new { c.wfID, c.wfTitle, c.wfRemark, c.wfStatus }).ToList();
            return Json(new { Rows=list,Total=0 });
        }

        #endregion
        #region 设置节点
        
       
        [HttpGet]
        public ActionResult setNodes(int id)
        {
            ViewBag.wfid = id;
            return View();
 
        }
        /// <summary>
        /// 获取id下面所有节点数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost,SkipcheckPermiss]
        public ActionResult getNodes(int id)
         {
             var list = worknodesSer.QueryJoin(c => c.wfID == id, new string[] { "sysKeyvalue" }).Select(c => new
             {
                 
                 c.wfID,c.wfNodeTitle,c.wfnOrderNo,
                 NodeType=c.sysKeyValue.KName,
                 RoleType=c.sysKeyValue1.KName,
                 c.wfNodeType,
                 //24 为syskeyvalue中表示 执行节点
                 Biz = c.wfNodeType == (int)Enums.EnodeType.processNode? c.wfnBizMethod + ("(targentNum," + c.wfnMaxNum+")") : ""
             });
             return Json(new { Rows=list});
         }
        #endregion
        #region 新增节点

        [HttpGet, SkipcheckPermiss]
        public ActionResult addNode(int id)
        {
            setNodesType();
            setRoleType();
            return View();
        }
        
         [HttpPost,SkipcheckPermiss]
        public ActionResult addNode(int id,wfWorkNodesView model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return WriteEroor("实体验证失败");
                }
                model.wfID = id;
                model.fCreateTime = DateTime.Now;
                model.fCreatorID = UserMgr.GetCurrentUserinfo().uID;
                model.fUpdateTime = DateTime.Now;
                worknodesSer.add(model.EntityMap());
                worknodesSer.SaveChanges();

                return WriteSuccess("节点添加成功");
            }
            catch (Exception ex)
            {
                return WriteEroor(ex);
            }

        }

        #endregion
        #region 辅助方法
        private void setNodesType()
        {
            var list = keyvalSer.QueryWhere(c => c.KType == (int)Enums.EKeyvalueType.NodeType);
            SelectList clist = new SelectList(list, "KID", "KName");
            ViewBag.nodetypes = clist;
        }
        private void setRoleType()
        {
            var list = keyvalSer.QueryWhere(c => c.KType == (int)Enums.EKeyvalueType.RoleType);
            SelectList clist = new SelectList(list, "KID", "KName");
            ViewBag.roletypes = clist;
        }
        #endregion
    }
}
