using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CRM.Site.Areas.admin.Controllers
{
    using CRM.Common;
    using System.Drawing;
    using WebHelper;
    [SkipCheckLogin, SkipcheckPermiss]
    public class VcodeController : BaseController
    {
        //
        // GET: /admin/Vcode/
        [HttpGet]
        public ActionResult Vcode()
        {
            //生成一个验证码字符串
            string vcode = GetVcode(1);
            //验证码存入session
            Session[Keys.vcode] = vcode;
            byte[] imgbugffer; 
            //验证码画到图片上
            using (Image img = new Bitmap(65, 25))
            {
                using (Graphics g = Graphics.FromImage(img))
                {
                    g.Clear(Color.White);
                    g.DrawString(vcode, new Font("黑体", 16, FontStyle.Bold | FontStyle.Strikeout | FontStyle.Italic), 
new SolidBrush(Color.Red), 4, 4);
                }
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imgbugffer = ms.ToArray();
                }
            }

            return File(imgbugffer,"imgge/Jpeg");
        }

        Random r = new Random();
        private string GetVcode(int p)
        {
            string str = "2345678901abcdefghjkmnpqrstuvwxyzABCDEFGHJKMNPQRSTUVWXYZ";
            string res = string.Empty;
            int len = str.Length;
            for (int i = 0; i < p; i++)
            {
                res += str[r.Next(len)];
 
            }
            return res;
        }

    }
}
