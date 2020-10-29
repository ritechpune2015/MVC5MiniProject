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
    public class UserOrdersController : Controller
    {
        // GET: UserOrders
        MiniAppEntities entity = new MiniAppEntities();
        public ActionResult Index()
        {
            Int64 userid = Convert.ToInt64(Session["UserID"]);
            var order = entity.OrderTbls.Where(p => p.UserID == userid);
            return View(order);
        }

        public ActionResult Details(Int64 id)
        {
            var orderdet = entity.OrderTbls.Find(id);
            return View(orderdet);
        }
    }
}