using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.WebHelper
{
    using System.Web.Mvc;
    using CRM.Common;
    using System.Web;
    using CRM.IServices;
    using Autofac;
    public class CheckPermissAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //检查有无跳过特性检查的标签
            if (filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(SkipcheckPermiss), false))
            {
                return;
            }
            //检查控制器方法上有无跳过特性检查的标签
            if (filterContext.ActionDescriptor.IsDefined(typeof(SkipcheckPermiss), false))
            {
                return;
            }
            //获取当前触发此OnActionExecuting的action
            string actionName = filterContext.ActionDescriptor.ActionName.ToLower();
            //控制名称
            string controlerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();
            //获取区域的名称
            string areaName = string.Empty;
            if (filterContext.RouteData.DataTokens.ContainsKey("area"))
            {
                areaName = filterContext.RouteData.DataTokens["area"].ToString().ToLower();
            }
            //根据上面三个成员的值作为条件去当前用户的缓存中获取
            var cont = CacheMgr.GetData<IContainer>(Keys.AutofacContainer);
            IsysPermissListServices iPerSer = cont.Resolve<IsysPermissListServices>();
            var list = iPerSer.GetFunctionsForUserByCache(UserMgr.GetCurrentUserinfo().uID);
            var isOK = list.Any(c => c.mArea.ToLower() == areaName && c.mController.ToLower() == controlerName && c.fFunction.ToLower() == actionName);
            if (isOK == false)
            {
               isOK = list.Any(c => c.mArea.ToLower() == areaName
               && c.mController.ToLower() == controlerName
               && c.mAction.ToLower() == actionName);
            }
            if (isOK == false)
            {
                ToLogin(filterContext);
            }

            
        }

        private static void ToLogin(ActionExecutingContext filterContext)
        {
            bool isAjaxRequest = filterContext.HttpContext.Request.IsAjaxRequest();

            if (isAjaxRequest)
            {
                JsonResult json = new JsonResult();
                json.Data = new { status = Enums.EAjaxState.error, msg = "无权限访问此页面" };
                json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                filterContext.Result = json;

            }
            else
            {
                ViewResult view = new ViewResult();
                view.ViewName = "~/Areas/admin/Views/Shared/NoPermiss.cshtml";
                filterContext.Result = view;
            }
        }
    }
}
