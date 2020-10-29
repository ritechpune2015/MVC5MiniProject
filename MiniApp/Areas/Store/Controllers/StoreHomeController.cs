using MiniApp.CustFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniApp.Areas.Store.Controllers
{

    [StoreAuth]
    public class StoreHomeController : Controller
    {
        // GET: Store/StoreHome
        public ActionResult Index()
        {
            return View();
        }
    }
}