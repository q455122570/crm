using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model.ModelViews
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    //处理登录请求
    public class LoginInfo
    {
        [DisplayName("用户名"), Required(ErrorMessage="账号非空")]
        public string uLoginName { get; set; }
        [DisplayName("密码"), Required(ErrorMessage = "密码非空")]
        public string uLoginPwd { get; set; }
        [DisplayName("验证码"), Required(ErrorMessage = "验证码非空")]
        public string Vcode { get; set; }
        /// <summary>
        /// 是否记住3天
        /// </summary>
        public bool IsMember { get; set; }
    }
}
