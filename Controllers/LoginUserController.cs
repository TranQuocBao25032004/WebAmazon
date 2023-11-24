using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAmazon.Models;

namespace WebAmazon.Controllers
{
    public class LoginUserController : Controller
    {
        DBAmaZEntities db = new DBAmaZEntities();
        // GET: LoginUser
        public ActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult LoginAccount(AdminUser _user)
        //{
        //    var check = db.AdminUser.Where(s => s.PasswordUser == _user.PasswordUser).FirstOrDefault();
        //    if (check == null)
        //    {
        //        ViewBag.ErrorInfo = "SaiInfo";
        //        return View("Index");
        //    }
        //    else
        //    {
        //        db.Configuration.ValidateOnSaveEnabled = false;
        //        Session["PasswordUser"] = _user.PasswordUser;
        //        return RedirectToAction("Index", "Product");
        //    }
        //}
    }
}
