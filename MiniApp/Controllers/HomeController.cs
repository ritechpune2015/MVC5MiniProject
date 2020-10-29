using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniApp.Models;
namespace MiniApp.Controllers
{
    public class HomeController : Controller
    {
        MiniAppEntities entity = new MiniAppEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult GetMenu()
        {

            return PartialView("_Menu", entity.MainCategoryTbls.ToList());
        }

        public ActionResult GetProducts(Int64 id=0)
        {
            if (id == 0)
                return View(entity.ProductTbls.ToList());
            else
            {
                var v = entity.ProductTbls.Where(p => p.CategoryID == id);
                return View(v.ToList());
            }
        }

        public PartialViewResult GetCategories()
        {
            return PartialView("_CategoryList",entity.CategoryTbls.ToList());
        }

        public PartialViewResult GetCartCount()
        {
            int count = 0;
            if (Session["UserID"] != null)
            {
                Int64 userid = Convert.ToInt64(Session["UserID"]);
                count = entity.CartTbls.Count(p => p.UserID == userid);
            }
            return PartialView("_CartCount",count);
        }

    }
}