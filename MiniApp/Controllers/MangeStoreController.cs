using MiniApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniApp.Controllers
{
    public class MangeStoreController : Controller
    {
        // GET: MangeStore
        MiniAppEntities entity = new MiniAppEntities();
            [HttpGet]
        public ActionResult doLogin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult doLogin(StoreLoginVM rec)
        {

            if (ModelState.IsValid)
            {
                StoreTbl srec = entity.StoreTbls.SingleOrDefault(p => p.EmailID == rec.EmailID && p.Password == rec.Password);
                if (srec != null)
                {
                    Session["StoreID"] = srec.StoreID;
                    Session["StoreName"] = srec.StoreName;
                    return RedirectToAction("Index", "StoreHome", new { area = "Store" });
                }
               ModelState.AddModelError("", "Invalid EmailID or Password!");
               return View(rec);
            }
            return View(rec);
        }


        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("doLogin");
        }
    }
}