using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAmazon.Models;
using WebAmazon.Models.ViewModel;
using PagedList;
using PagedList.Mvc;
namespace WebAmazon.Controllers
{
    public class ProductsController : Controller
    {
        private DBAmaZEntities db = new DBAmaZEntities();
        //Cac chuc nang cua khach hang
        //Xem danh sach san pham 
        public ActionResult ProductList()
        {
            List<ProDetail> proDetail = db.ProDetails.Include(p => p.Product)
                .Include(p => p.Color).Include(p => p.Supplier)
                .Where(p => p.RemainQuantity>0).ToList();
            return View(proDetail);
        }
        //Cac chuc nang cua phan Admin
        //Xem danh sach Them-Xoa-Sua chi tiet san pham
        // GET: Products : xem danh sach san pham
        public ActionResult Index(string _name)
        {
            if (_name == null)
            {
                var products = db.Products.Include(p => p.Category);
                return View(products.ToList());
            }
            else
            {
                var products = db.Products.Include(p => p.Category);
                return View(db.Products.Where(s => s.ProName.Contains(_name)).ToList());
            }
                


        }
        //[ChildActionOnly]
        //public List<ProDetail> RemainProducts(int? proId = 1)
        //{
        //    if(proId != null)
        //    {

        //    }
        //}
        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CatID = new SelectList(db.Categories, "CatID", "NameCate");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProID,ProName,CatID,ProImage,NameDecription,CreatedDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CatID = new SelectList(db.Categories, "CatID", "NameCate", product.CatID);
            return View(product);
        }
        public ActionResult UpLoadProduct()
        {
            ViewBag.CatID = new SelectList(db.Categories, "CatID", "NameCate");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpLoadProduct([Bind(Include = "ProID,ProName,CatID,ProImage,NameDecription,CreatedDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.UploadImage != null)
                {
                    string path = "~/Content/image";
                    string filename = Path.GetFileName(product.UploadImage.FileName);
                    product.ProImage = path + filename;
                    product.UploadImage.SaveAs(Path.Combine(Server.MapPath(path), filename));
                }
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.CatID = new SelectList(db.Categories, "CatID", "NameCate", product.CatID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatID = new SelectList(db.Categories, "CatID", "NameCate", product.CatID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProID,ProName,CatID,ProImage,NameDecription,CreatedDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatID = new SelectList(db.Categories, "CatID", "NameCate", product.CatID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult ProductListCategory(int? style)
        {
            if (style != null)
                return View(db.Products.Where(s => s.CatID == style).ToList());
            else
                return View(db.Products.ToList());
        }
        //public ActionResult ListNeedRestock(int? i)
        //{
        //    List<ViewRestock> ListNeedRestock1 = 
        //    return View();
        //}
        
    }
}
