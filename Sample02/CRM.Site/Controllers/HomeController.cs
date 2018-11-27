using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Site.Controllers
{
    using IServices;
    using Model.ModelViews;
    using EntityMapping;
    using CRM.WebHelper;
    /// <summary>
    /// DefaulConntrollerFactory
    /// </summary>
    public class HomeController : BaseController
    {
        public HomeController(IsysFunctionServices funSer,IsysKeyValueServices keyvalueSer)
        {
            base.funSer = funSer;
            base.keyvalSer = keyvalueSer;
        }
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var model = base.funSer.QueryWhere(c => c.fID == 5).Select(c => c.EntityMap()).FirstOrDefault();
            model.fName += "1";

            var keyvalueModel = base.keyvalSer.QueryWhere(c => c.KID == 2).FirstOrDefault();
            keyvalueModel.KName += "1";
            keyvalSer.SaveChanges();
            return View(model);
        }

    }
}
