using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.WebHelper
{
    using System.Web.Mvc;
    using IServices;
    using CRM.Common;
    //控制器父类
    public class BaseController:Controller
    {
        //1.定义当前系统中所有的业务逻辑层的接口成员
        protected IsysFunctionServices funSer;
        protected IsysKeyValueServices keyvalSer;
        protected IsysMenusServices menuSer;
        protected IsysOrganStructServices organSer;
        protected IsysPermissListServices permissSer;
        protected IsysRoleServices roleSer;
        protected IsysUserInfoServices userinfoSer;
        protected IsysUserInfo_RoleServices userinfoRoleSer;
        protected IwfProcessServices processSer;
        protected IwfRequestFormServices requestformSer;
        protected IwfWorkServices workSer;
        protected IwfWorkBranchServices workbranchSer;
        protected IwfWorkNodesServices worknodesSer;


        //请求返回方法
        protected ActionResult WriteSuccess(string msg)
        {
            return Json(new { status = (int)Enums.EAjaxState.sucess, msg =msg });
        }
        protected ActionResult WriteSuccess(string msg, object obj)
        {
            return Json(new { status = (int)Enums.EAjaxState.sucess, msg = msg, datas = obj });
        }
        protected ActionResult WriteEroor(string errmsg)
        {
            return Json(new { status = (int)Enums.EAjaxState.error, msg = errmsg });
        }
        protected ActionResult WriteEroor(Exception ex)
        {
            Exception innerEx = ex.InnerException == null ? ex : ex.InnerException;
            while (innerEx.InnerException != null)
            {
                innerEx = innerEx.InnerException;
 
            }
            return Json(new { status = (int)Enums.EAjaxState.error, msg = innerEx.Message });
        }

        protected virtual void SetStatus()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(0, "正常");
            dic.Add(1, "停用");

            SelectList clist = new SelectList(dic, "Key", "Value");

            ViewBag.status = clist;
        }
    }
}
