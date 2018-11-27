using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.WebHelper
{
    using CRM.Common;
    using Model;
    using System.Web;

    public class UserMgr
    {
        public static sysUserInfo GetCurrentUserinfo()
        {
            if (HttpContext.Current.Session[Keys.uinfo] != null)
            {
                return HttpContext.Current.Session[Keys.uinfo] as sysUserInfo;
            }
            return new sysUserInfo() { };
        }
    }
}
