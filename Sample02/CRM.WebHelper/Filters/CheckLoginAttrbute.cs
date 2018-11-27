using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.WebHelper
{
    using CRM.Common;
    using System.Web;
    using System.Web.Mvc;
    using CRM.IServices;
    using Autofac;
    public  class CheckLoginAttrbute:ActionFilterAttribute
    {   

        /// <summary>
        /// 统一验证session
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //检查有无跳过特性检查的标签
            if (filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(SkipCheckLogin), false))
            {
                return;
            }
            //检查控制器方法上有无跳过特性检查的标签
            if (filterContext.ActionDescriptor.IsDefined(typeof(SkipCheckLogin), false))
            {
                return;
            }
            //判断session是否为空
            if (filterContext.HttpContext.Session[Keys.uinfo] == null)
            {
                //查询cookies是否选中记住用户，成立则模拟登陆
                if (filterContext.HttpContext.Request.Cookies[Keys.IsMember] !=null)
                {
                    string uid = filterContext.HttpContext.Request.Cookies[Keys.IsMember].Value;
                    //根据uid查出用户实体
                    var cont= CacheMgr.GetData<IContainer>(Keys.AutofacContainer);
                    IsysUserInfoServices usrSer = cont.Resolve<IsysUserInfoServices>();
                    //根据uid查询数据用户信息
                    int iuserid = int.Parse(uid);
                    var userinfo = usrSer.QueryWhere(c => c.uID == iuserid).FirstOrDefault();
                    if (userinfo != null)
                    {
                        filterContext.HttpContext.Session[Keys.uinfo] = userinfo;
                    }
                    else 
                    {
                        ToLogin(filterContext);
                    }
 
                }
                else { 
                //ContentResult cr =new ContentResult();
                //cr.Content = "<script>alter('您未登录');window.location='/admin/login/login';</script>";
                ToLogin(filterContext);
                }
            }


            base.OnActionExecuting(filterContext);
        }

        private static void ToLogin(ActionExecutingContext filterContext)
        {
            bool isAjaxRequest = filterContext.HttpContext.Request.IsAjaxRequest();

            if (isAjaxRequest)
            {
                JsonResult json = new JsonResult();
                json.Data = new { status = Enums.EAjaxState.nologin, msg = "您未登录" };
                json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                filterContext.Result = json;
 
            }
            else { 
            ViewResult view = new ViewResult();
            view.ViewName = "~/Areas/admin/Views/Shared/Tip.cshtml";
            filterContext.Result = view;
            }
        }
    }
}
