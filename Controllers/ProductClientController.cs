using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAmazon.Models;
using PagedList;
using PagedList.Mvc;

namespace WebAmazon.Controllers
{
    public class ProductClientController : Controller
    {
       DBAmaZEntities database = new DBAmaZEntities();

        // GET: ProductClient
        public ActionResult Index(int? style /*,int?page*/)
        {
            //int pageSize = 4;
            //int pageNum = (page ?? 1);   
            if (style != null)

                return View(database.ProDetails.Where(s => s.Product.CatID == style)/*.ToPagedList(pageNum,pageSize)*/.ToList());
            else
                return View(database.ProDetails.ToList());
        }
    }
}