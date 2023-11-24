using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAmazon.Models;
namespace WebAmazon.Controllers
{
    public class StyleController : Controller
    {
        DBAmaZEntities database = new DBAmaZEntities();
        // GET: Style
        public ActionResult Index()
        {
            var list = database.Categories.ToList();
            ViewBag.listCat = list;
            return PartialView(list);
        }
    }
}