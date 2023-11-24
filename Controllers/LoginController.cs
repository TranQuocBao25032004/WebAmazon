using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAmazon.Models;
namespace WebAmazon.Controllers
{
    public class LoginController : Controller
    {
        DBAmaZEntities database = new DBAmaZEntities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult AuthenLogin( Customer _user)
        {
            try
            {
                var check_Pass = database.Customers.Where(s => s.CusPassword == _user.CusPassword).FirstOrDefault();
                var check_Name = database.Customers.Where(s => s.CusName == _user.CusName).FirstOrDefault();
                var check_Phone = database.Customers.Where(s => s.CusPhone == _user.CusPhone).FirstOrDefault();
                var check_Email = database.Customers.Where(s => s.CusEmail == _user.CusEmail).FirstOrDefault();
                if (check_Pass == null || check_Name == null)
                {
                    if(check_Name == null) {
                        ViewBag.ErrorName = "Name not match";
                    }
                    if(check_Pass == null) {
                        ViewBag.ErrorPass = "Password  not match";
                    }
                    if(check_Phone == null)
                    {
                        ViewBag.ErrorPhone = "Phone not match";
                    }
                    if(check_Email == null)
                    {
                        ViewBag.ErrorEmail = " Email not match";
                    }
                    return View("Login");
                }
                else
                {
                    Session["CusName"] =_user.CusName;
                    Session["CusPhone"]=_user.CusPhone;
                    return RedirectToAction("Home","Home");
                }

            }
            catch { 
                return View("Login");
            }
        }
        public ActionResult Register()
        { 
            return View();
        }
        public ActionResult AuthenRegister(Customer _user) {
            try
            {
                database.Customers.Add(_user);
                database.SaveChanges();
                return RedirectToAction("Login");
            }
            catch {
                return View("Register");
            }
            
        }

    }
}