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
    public class CategoryController : Controller
    {
        private MiniAppEntities db = new MiniAppEntities();

        // GET: Store/Category
        public ActionResult Index()
        {
            var categoryTbls = db.CategoryTbls.Include(c => c.MainCategoryTbl);
            return View(categoryTbls.ToList());
        }

        // GET: Store/Category/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTbl categoryTbl = db.CategoryTbls.Find(id);
            if (categoryTbl == null)
            {
                return HttpNotFound();
            }
            return View(categoryTbl);
        }

        // GET: Store/Category/Create
        public ActionResult Create()
        {
            ViewBag.MainCategoryID = new SelectList(db.MainCategoryTbls, "MainCategoryID", "MainCategory");
            return View();
        }

        // POST: Store/Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,MainCategoryID,CategoryName")] CategoryTbl categoryTbl)
        {
            if (ModelState.IsValid)
            {
                db.CategoryTbls.Add(categoryTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MainCategoryID = new SelectList(db.MainCategoryTbls, "MainCategoryID", "MainCategory", categoryTbl.MainCategoryID);
            return View(categoryTbl);
        }

        // GET: Store/Category/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTbl categoryTbl = db.CategoryTbls.Find(id);
            if (categoryTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.MainCategoryID = new SelectList(db.MainCategoryTbls, "MainCategoryID", "MainCategory", categoryTbl.MainCategoryID);
            return View(categoryTbl);
        }

        // POST: Store/Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,MainCategoryID,CategoryName")] CategoryTbl categoryTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MainCategoryID = new SelectList(db.MainCategoryTbls, "MainCategoryID", "MainCategory", categoryTbl.MainCategoryID);
            return View(categoryTbl);
        }

        // GET: Store/Category/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTbl categoryTbl = db.CategoryTbls.Find(id);
            if (categoryTbl == null)
            {
                return HttpNotFound();
            }
            return View(categoryTbl);
        }

        // POST: Store/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CategoryTbl categoryTbl = db.CategoryTbls.Find(id);
            db.CategoryTbls.Remove(categoryTbl);
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
