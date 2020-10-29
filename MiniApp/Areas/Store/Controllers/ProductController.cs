using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiniApp.CustFilter;
using MiniApp.Models;

namespace MiniApp.Areas.Store.Controllers
{

    [StoreAuth]
    public class ProductController : Controller
    {
        private MiniAppEntities db = new MiniAppEntities();

        // GET: Store/Product
        public ActionResult Index()
        {
            var productTbls = db.ProductTbls.Include(p => p.CategoryTbl);
            return View(productTbls.ToList());
        }

        // GET: Store/Product/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTbl productTbl = db.ProductTbls.Find(id);
            if (productTbl == null)
            {
                return HttpNotFound();
            }
            return View(productTbl);
        }

        // GET: Store/Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.CategoryTbls, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Store/Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,CategoryID,ProductDesc,Price,MfgName,ImagePath")] ProductTbl productTbl,HttpPostedFileBase PhotoFile)
        {
            if (ModelState.IsValid)
            {
                string path = "";
                if (PhotoFile != null)
                {
                    path = "~/productphotos/" + PhotoFile.FileName;
                    PhotoFile.SaveAs(Server.MapPath(path));
                    path = path.Substring(1, path.Length - 1);
                }

                productTbl.ImagePath = path;
                db.ProductTbls.Add(productTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.CategoryTbls, "CategoryID", "CategoryName", productTbl.CategoryID);
            return View(productTbl);
        }

        // GET: Store/Product/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTbl productTbl = db.ProductTbls.Find(id);
            if (productTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.CategoryTbls, "CategoryID", "CategoryName", productTbl.CategoryID);
            return View(productTbl);
        }

        // POST: Store/Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,CategoryID,ProductDesc,Price,MfgName,ImagePath")] ProductTbl productTbl,HttpPostedFileBase PhotoFile)
        {
            if (ModelState.IsValid)
            {
                string path = "";
                if (PhotoFile != null)
                {
                    path = "~/productphotos/" + PhotoFile.FileName;
                    PhotoFile.SaveAs(Server.MapPath(path));
                    path = path.Substring(1, path.Length - 1);
                    productTbl.ImagePath = path;
                }

                db.Entry(productTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.CategoryTbls, "CategoryID", "CategoryName", productTbl.CategoryID);
            return View(productTbl);
        }

        // GET: Store/Product/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTbl productTbl = db.ProductTbls.Find(id);
            if (productTbl == null)
            {
                return HttpNotFound();
            }
            return View(productTbl);
        }

        // POST: Store/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ProductTbl productTbl = db.ProductTbls.Find(id);
            db.ProductTbls.Remove(productTbl);
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
    }
}
