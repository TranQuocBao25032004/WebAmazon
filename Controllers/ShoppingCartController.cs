using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAmazon.Models;

namespace WebAmazon.Controllers
{
    public class ShoppingCartController : Controller
    {
        DBAmaZEntities database = new DBAmaZEntities();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowCart()
        {
            if (Session["Cart"] == null)
                return View("EmptyCart");
            Cart _cart = Session["Cart"] as Cart;
            return View(_cart);
        }
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;

            }
            return cart;
        }
        public ActionResult AddToCart(int id)
        {
            var _pro = database.ProDetails.SingleOrDefault(s => s.ProID == id);
            if (_pro != null)
            {
                GetCart().Add_Product_Cart(_pro);

            }
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public ActionResult Update_Cart_Quantity(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["idPro"]);
            int _quantity = int.Parse(form["cartQuantity"]);
            cart.Update_quantity(id_pro, _quantity);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public PartialViewResult BagCart()
        {
            int toltal_quantity_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)

                toltal_quantity_item = cart.Total_quantity();


            ViewBag.QuantityCart = toltal_quantity_item;
            return PartialView("BagCart");
        }
        public ActionResult CheckOut(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                Order _order = new Order();
                _order.OrderDate = DateTime.Now;
                _order.AddressDeliverry = form["AddressDeliverry"];
                _order.CusPhone = form["CusPhone"];
                database.Orders.Add(_order);
                foreach(var item in cart.Items)
                {
                    OrderDetail _order_detail = new OrderDetail();
                    _order_detail.OrderID = _order.OrderID;  
                  // _order_detail.ProSupID= item._product.ProDeID;
                    _order_detail.UnitPrice = (double)item._product.Price;
                    _order_detail.Quantity = item._quantity;
                    database.OrderDetails.Add(_order_detail);
                }
                database.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("CheckOut_Sucess", "ShoppingCart");
            }

            catch
            {
               return Content("Error checkout . Please check information of Customer");
            }
        }
        public ActionResult CheckOut_Sucess()
        {
            return View();
        }
       

    }
}