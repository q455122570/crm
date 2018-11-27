
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Site.Areas.admin.Controllers
{
    using CRM.Model.ModelViews;
    using IServices;
    using CRM.WebHelper;
    using CRM.Common;
    using System.Web.WebPages;
    [SkipCheckLogin,SkipcheckPermiss]
    public class LoginController : BaseController
    {
        public LoginController(IsysUserInfoServices userSer,IsysPermissListServices pSer)
        {
            base.userinfoSer = userSer;
            base.permissSer = pSer;
        }
        #region 登录
        /// <summary>
        /// 返回登录视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            LoginInfo info = new LoginInfo()
            {
                uLoginName = "admin",
                IsMember = false
            };
            //判断cookie中记住3天是否勾上
            if (Request.Cookies[Keys.IsMember] != null)
            {
                info.IsMember = true;
            }
            return View(info);
        }


        /// <summary>
        /// 接收登录页面提交的数据，进行处理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(LoginInfo model)
        {
            try
            {
                //实体验证
                if(ModelState.IsValid==false)
                {
                    return WriteEroor("实体验证失败！");
                }
                //
                string vcodefromsession=string.Empty;
                if(Session[Keys.vcode]!=null)
                {
                    vcodefromsession=Session[Keys.vcode].ToString();
                }
                if(model.Vcode.IsEmpty() ||
                    vcodefromsession.Equals(model.Vcode,StringComparison.OrdinalIgnoreCase)==false){
                        return WriteEroor("验证码不合法");
                }
                //用户名密码正确性
                string md5PWD = Kits.MD5Entry(model.uLoginPwd);
                var userinfo=userinfoSer.QueryWhere(c=>c.uLoginName==model.uLoginName&&
                    c.uLoginPWD == md5PWD).FirstOrDefault();
                if(userinfo==null)
                {
                    return WriteEroor("用户名或密码错误");
                }
                //登录用户信息存入session
                Session[Keys.uinfo]=userinfo;
                //判断是否选中记住3天，成立写入cookies
                if (model.IsMember == true)
                {
                    //DES加密
                    HttpCookie cookie = new HttpCookie(Keys.IsMember,userinfo.uID.ToString());
                    cookie.Expires = DateTime.Now.AddDays(3);
                    Response.Cookies.Add(cookie);
                }
                else {
                    //清除
                    HttpCookie cookie = new HttpCookie(Keys.IsMember,"");
                    cookie.Expires = DateTime.Now.AddDays(-3);
                    Response.Cookies.Add(cookie);
                }
                //将当前用户权限按钮缓存起来,永久有效，当管理员用户分配角色和设置此角色权限菜单时候，缓存失效
                permissSer.GetFunctionsForUserByCache(userinfo.uID);

                //登录成功消息
                return WriteSuccess("登录成功");
            }
            catch (Exception ex) 
            {
                return WriteEroor(ex);
            }

           // return View();
        }
        
        
        #endregion
        #region 登出
        
        
        [HttpGet]
        public ActionResult Layout() {
        
            //清空session
            Session[Keys.uinfo] = null;
            //跳转登录界面
            return RedirectToAction("Login", "Login");
        }
        #endregion
    }
}
