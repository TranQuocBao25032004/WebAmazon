using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAmazon.Models;
using WebAmazon.Models.ViewModel;

namespace WebAmazon.Controllers
{
    public class DetailProductController : Controller
    {
        private DBAmaZEntities db = new DBAmaZEntities();
        // GET: DetailProduct
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DetailProduct(int? id = 1)
        {
            if (id != null)
            {
                ProDetail pro = db.ProDetails.FirstOrDefault(p => p.ProDeID == id);
                DetailProductVM detailProductVM = new DetailProductVM
                {
                    //proDetail
                    ProDeID = pro.ProDeID,
                    Price = pro.Price,
                    RemainQuantity = pro.RemainQuantity,
                    SoldQuantity = pro.SoldQuantity,
                    ViewQuantity = pro.ViewQuantity,

                    //product
                    ProID = pro.ProID,
                    ProName = pro.Product.ProName,
                    ProImage = pro.Product.ProImage,
                    NameDecription = pro.Product.NameDecription,

                    //category
                    CatID = pro.Product.CatID,
                    NameCate = pro.Product.Category.NameCate,


                    //Supplier
                    SupID = pro.SupID,
                    SupName = pro.Supplier.SupName,
                    Address = pro.Supplier.Address,

                    //Color
                    ColorID = pro.ColorID,
                    ColorName = pro.Color.ColorName,
                    RGB = pro.Color.RGB,

                    //RelatedProducts(CatID)
                    RelatedProducts = RelatedProduct(pro.Product.CatID)
                    
                };
                return View(detailProductVM);
            }


            return Content("Missing ID ");
        }
        public List<DetailProductVM> RelatedProduct(int? catid = 1)
        {
            if(catid != null)
            {
                List<ProDetail> proDetails = db.ProDetails.Where(p => p.Product.CatID ==catid).ToList();
                List<DetailProductVM> relatedProduct = proDetails.Select(
                    pro => new DetailProductVM
                    {
                        //proDetail
                        ProDeID = pro.ProDeID,
                        Price = pro.Price,
                        RemainQuantity = pro.RemainQuantity,
                        SoldQuantity = pro.SoldQuantity,
                        ViewQuantity = pro.ViewQuantity,

                        //product
                        ProID = pro.ProID,
                        ProName = pro.Product.ProName,
                        ProImage = pro.Product.ProImage,
                        NameDecription = pro.Product.NameDecription,

                        //category
                        CatID = pro.Product.CatID,
                        NameCate = pro.Product.Category.NameCate,


                        //Supplier
                        SupID = pro.SupID,
                        SupName = pro.Supplier.SupName,
                        Address = pro.Supplier.Address,

                        //Color
                        ColorID = pro.ColorID,
                        ColorName = pro.Color.ColorName,
                        RGB = pro.Color.RGB,
                    }).ToList();
                return relatedProduct;
            }
            return null;
        }
        
        public ActionResult ProductByCategory(int?catid =1)
        {
            return PartialView(RelatedProduct(catid));
        }
    }
}