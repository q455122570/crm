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
    public class OrganController : BaseController
    {
        public OrganController(IsysOrganStructServices Oser)
        {
            base.organSer = Oser;
        }
        //
        // GET: /admin/Organ/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult getlist()
        {
            string kname = Request.Form["kname"];
            object list;
            if (kname.IsEmpty())
            {
                list = organSer.QueryJoin(c => true, new string[] { "sysKeyvalue" })
               .Select(c => new
               {
                   c.osID,
                   c.osParentID,
                   c.osName,
                   c.osCode,
                   c.sysKeyValue.KName
                   ,
                   c.osShortName,
                   c.osStatus,
                   c.osRemark
               });
            }
            else { 
            //获取组织结构中的正常数据
                list = organSer.QueryJoin(c => c.osName.Contains(kname), new string[] { "syskeyvalue" }).Select(c => new { c.osID, c.osParentID, c.osName, c.osCode, c.sysKeyValue.KName, c.osShortName, c.osStatus, c.osRemark });

            } 
            return Json(new { Rows = list, Total = 0 });
        }
    }
}
