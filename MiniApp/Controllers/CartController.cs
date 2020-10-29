using MiniApp.CustFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniApp.Models;
namespace MiniApp.Controllers
{
    [UserAuth]
    public class CartController : Controller
    {
        // GET: Cart
        MiniAppEntities entity = new MiniAppEntities();
        public ActionResult AddToCart(Int64 id=0)
        {
            Int64 userid = Convert.ToInt64(Session["UserID"]);
            ProductTbl prec = entity.ProductTbls.SingleOrDefault(p => p.ProductID == id);
            var usercart = entity.CartTbls.Where(p => p.UserID == userid).ToList();
            if (usercart != null)
            {
                CartTbl prodcart = usercart.SingleOrDefault(p => p.ProductID == id);
                if (prodcart != null)
                {
                    prodcart.Qty++;
                    entity.SaveChanges();
                }
                else
                {
                    CartTbl newcart = new CartTbl();
                    newcart.Price = prec.Price;
                    newcart.ProductID = id;
                    newcart.Qty = 1;
                    newcart.UserID = userid;
                    entity.CartTbls.Add(newcart);
                    entity.SaveChanges();
                }


            }
            else
            {
                CartTbl newcart = new CartTbl();
                newcart.Price = prec.Price;
                newcart.ProductID = id;
                newcart.Qty = 1;
                newcart.UserID = userid;
                entity.CartTbls.Add(newcart);
                entity.SaveChanges();

                
            }
            return RedirectToAction("GetProducts", "Home",new {id=prec.CategoryID});
        }

        public ActionResult GetCart()
        {
            Int64 userid = Convert.ToInt64(Session["UserID"]);
            var cart = entity.CartTbls.Where(p => p.UserID == userid);
            return View(cart);
        }
        public ActionResult RemoveCart(Int64 id)
        {
            CartTbl crec = entity.CartTbls.Find(id);
            entity.CartTbls.Remove(crec);
            entity.SaveChanges();
            return RedirectToAction("GetCart");
        }
        public JsonResult UpdateCart(Int64 CartID, int Qty)
        {
            CartTbl rec = entity.CartTbls.Find(CartID);
            rec.Qty = Qty;
            entity.SaveChanges();
            return Json("", JsonRequestBehavior.AllowGet);
        }
        public ActionResult CheckOut(int PaymentMode = 0)
        {
            if (PaymentMode == 1)
            {
                //place order
                return RedirectToAction("PlaceOrder", new { id = 1 });
            }
            else
            {
                return RedirectToAction("PaymentGateway");
            }
        }
        public ActionResult PlaceOrder(int id)
        {
            Int64 userid =Convert.ToInt64(Session["UserID"]);
            var usercart = entity.CartTbls.Where(p => p.UserID == userid);
            //Store in ordertbl
            decimal? amount = usercart.Sum(p => p.Price * p.Qty);
            OrderTbl order = new OrderTbl();
            order.OrderDate = DateTime.Now;
            order.UserID = userid;
            order.PaymentMode = id;
            entity.OrderTbls.Add(order);
            entity.SaveChanges();


            //order details
            foreach (var temp in usercart)
            {
                OrderDetTbl ordet = new OrderDetTbl();
                ordet.OrderID = order.OrderID;
                ordet.Price = temp.Price;
                ordet.Qty = temp.Qty;
                ordet.ProductID = temp.ProductID;
                entity.OrderDetTbls.Add(ordet);
            }
            entity.SaveChanges();

            var newusercart = entity.CartTbls.Where(p => p.UserID == userid);
            foreach (var temp in newusercart)
            {
                entity.CartTbls.Remove(temp);
            }
            entity.SaveChanges();

            ViewBag.OrderID = order.OrderID;
            ViewBag.Amount = amount;
            return View();
        }
        [HttpGet]
        public ActionResult PaymentGateway()
        {
            return View();
        }


        [HttpPost]
        public ActionResult PaymentGateWay()
        {
            return RedirectToAction("PlaceOrder", new { id = 2 });
        }
    }
}