using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniApp.CustFilter;
using MiniApp.Models;
namespace MiniApp.Areas.Store.Controllers
{

    [StoreAuth]
    public class OrdersController : Controller
    {
        // GET: Store/Orders
        MiniAppEntities entity = new MiniAppEntities();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetNewOrders()
        {

            var neworders = from t in entity.OrderTbls
                            where 
                            !(from t1 in entity.OrderDispatchTbls
                                    select t1.OrderID).Contains(t.OrderID)
                            select t;
            return PartialView("_NewOrders", neworders.ToList());
        }

        [HttpGet]
        public ActionResult Dispatch(Int64 id)
        {
            OrderTbl rec = entity.OrderTbls.Find(id);
            ViewBag.OrderID = rec.OrderID;
            ViewBag.OrderDate = rec.OrderDate;
            ViewBag.UserName = rec.UserTbl.UserName;
            ViewBag.AgencyID = new SelectList(entity.DispatchAgencyTbls.ToList(), "DispatchAgencyID", "DispatchAgencyName");
            return View();
        }

        [HttpPost]
        public ActionResult Dispatch(OrderDispatchTbl rec)
        {
            entity.OrderDispatchTbls.Add(rec);
            entity.SaveChanges();
            return RedirectToAction("Index");
        }
        public PartialViewResult GetDispatchedOrders()
        {
            var orders = from t in entity.OrderTbls
                         join t1 in entity.OrderDispatchTbls
                         on t.OrderID equals t1.OrderID
                         select t;
            return PartialView("_DispatchedOrders", orders.ToList());
        }

        public ActionResult Details(Int64 id)
        {
            OrderTbl ord = entity.OrderTbls.Find(id);
            return View(ord);
        }
    }
}