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
    public class MainCategoryController : Controller
    {
        private MiniAppEntities db = new MiniAppEntities();

        // GET: Store/MainCategory
        public ActionResult Index()
        {
            return View(db.MainCategoryTbls.ToList());
        }

        // GET: Store/MainCategory/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainCategoryTbl mainCategoryTbl = db.MainCategoryTbls.Find(id);
            if (mainCategoryTbl == null)
            {
                return HttpNotFound();
            }
            return View(mainCategoryTbl);
        }

        // GET: Store/MainCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/MainCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MainCategoryID,MainCategory")] MainCategoryTbl mainCategoryTbl)
        {
            if (ModelState.IsValid)
            {
                db.MainCategoryTbls.Add(mainCategoryTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mainCategoryTbl);
        }

        // GET: Store/MainCategory/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainCategoryTbl mainCategoryTbl = db.MainCategoryTbls.Find(id);
            if (mainCategoryTbl == null)
            {
                return HttpNotFound();
            }
            return View(mainCategoryTbl);
        }

        // POST: Store/MainCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MainCategoryID,MainCategory")] MainCategoryTbl mainCategoryTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mainCategoryTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mainCategoryTbl);
        }

        // GET: Store/MainCategory/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainCategoryTbl mainCategoryTbl = db.MainCategoryTbls.Find(id);
            if (mainCategoryTbl == null)
            {
                return HttpNotFound();
            }
            return View(mainCategoryTbl);
        }

        // POST: Store/MainCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            MainCategoryTbl mainCategoryTbl = db.MainCategoryTbls.Find(id);
            db.MainCategoryTbls.Remove(mainCategoryTbl);
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
