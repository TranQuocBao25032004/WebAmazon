using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAmazon.Models;
using PagedList;
using PagedList.Mvc;
namespace WebAmazon.Controllers
{
    public class ProDetailsController : Controller
    {
        private DBAmaZEntities db = new DBAmaZEntities();

        // GET: ProDetails
        public ActionResult Index(int?page)
        {
            //int pageSize = 4;
            //int pageNum =(page ??1);
            var proDetails = db.ProDetails.Include(p => p.Color).Include(p => p.Product).Include(p => p.Supplier);
            return View(proDetails./*ToPagedList(pageNum,pageSize)*/ToList());
        }

        // GET: ProDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProDetail proDetail = db.ProDetails.Find(id);
            if (proDetail == null)
            {
                return HttpNotFound();
            }
            return View(proDetail);
        }

        // GET: ProDetails/Create
        public ActionResult Create()
        {
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName");
            ViewBag.ProID = new SelectList(db.Products, "ProID", "ProName");
            ViewBag.SupID = new SelectList(db.Suppliers, "SupID", "SupName");
            return View();
        }

        // POST: ProDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProDeID,ProID,SupID,ColorID,Price,RemainQuantity,SoldQuantity,ViewQuantity")] ProDetail proDetail)
        {
            if (ModelState.IsValid)
            {
                db.ProDetails.Add(proDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", proDetail.ColorID);
            ViewBag.ProID = new SelectList(db.Products, "ProID", "ProName", proDetail.ProID);
            ViewBag.SupID = new SelectList(db.Suppliers, "SupID", "SupName", proDetail.SupID);
            return View(proDetail);
        }

        // GET: ProDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProDetail proDetail = db.ProDetails.Find(id);
            if (proDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", proDetail.ColorID);
            ViewBag.ProID = new SelectList(db.Products, "ProID", "ProName", proDetail.ProID);
            ViewBag.SupID = new SelectList(db.Suppliers, "SupID", "SupName", proDetail.SupID);
            return View(proDetail);
        }

        // POST: ProDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProDeID,ProID,SupID,ColorID,Price,RemainQuantity,SoldQuantity,ViewQuantity")] ProDetail proDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", proDetail.ColorID);
            ViewBag.ProID = new SelectList(db.Products, "ProID", "ProName", proDetail.ProID);
            ViewBag.SupID = new SelectList(db.Suppliers, "SupID", "SupName", proDetail.SupID);
            return View(proDetail);
        }

        // GET: ProDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProDetail proDetail = db.ProDetails.Find(id);
            if (proDetail == null)
            {
                return HttpNotFound();
            }
            return View(proDetail);
        }

        // POST: ProDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProDetail proDetail = db.ProDetails.Find(id);
            db.ProDetails.Remove(proDetail);
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
        //public ActionResult SearchOption(double min = double.MinValue, double max = double.MaxValue)
        //{
        //    var list = db.ProDetails.Where(p => (double)p.Price >= min && (double)p.Price <= max).ToList();
        //    return View(list);
        //}
        public ActionResult SearchOption(double min = double.MinValue, double max = double.MaxValue)
        {
            var list = db.ProDetails.Where(p => (double)p.Price >= min && (double)p.Price <= max).ToList();
            return View(list);
        }
    }
}
