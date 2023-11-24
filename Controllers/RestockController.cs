using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAmazon.Models;
using WebAmazon.Models.ViewModel;

namespace WebAmazon.Controllers
{
    public class RestockController : Controller
    {
        DBAmaZEntities db = new DBAmaZEntities();
        // GET: Restock
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ListNeedRestock1(int? i)
        {
            if (i != null)
            {
                List<ProDetail> proDetails = db.ProDetails.Where(p => p.Product.CatID == i || p.RemainQuantity <= i).ToList();
                List<ReStock> Viewliststock = proDetails.Select(
                    pro => new ReStock
                    {
                        //proDetail
                        ProDeID = pro.ProDeID,
                        RemainQuantity = pro.RemainQuantity,
                        //product
                        ProID = pro.ProID,
                        ProName = pro.Product.ProName,
                        ProImage = pro.Product.ProImage,
                        NameDecription = pro.Product.NameDecription,
                    }).ToList();
                return View(Viewliststock);
            }
            return null;
        }
    }
}