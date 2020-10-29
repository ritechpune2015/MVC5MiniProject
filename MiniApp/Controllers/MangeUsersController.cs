using MiniApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniApp.Controllers
{
    public class MangeUsersController : Controller
    {
        // GET: MangeUsers
        MiniAppEntities entity = new MiniAppEntities();

            [HttpGet]
        public ActionResult doLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult doLogin(UserLoginVM rec)
        {

            if (ModelState.IsValid)
            {
                UserTbl urec = entity.UserTbls.SingleOrDefault(p => p.EmailID == rec.EmailID && p.Password == rec.Password);
                if (urec != null)
                {
                    Session["UserID"] = urec.UserID;
                    Session["UserName"] = urec.UserName;
                    if (Session["ProdID"] != null)
                    {
                        Int64 prod = Convert.ToInt64(Session["ProdID"]);
                        Session.Remove("ProdID");
                        return RedirectToAction("AddToCart", "Cart",new {id=prod});

                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError("", "Invalid Email ID or Password!");
                return View(rec);
            }
            return View(rec);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("doLogin");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(UserTbl rec)
        {
            if (ModelState.IsValid)
            {
                entity.UserTbls.Add(rec);
                entity.SaveChanges();
                return RedirectToAction("doLogin");
           }

            return View(rec);
        }
    }
}