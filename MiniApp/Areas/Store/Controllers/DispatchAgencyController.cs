using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiniApp.Models;

namespace MiniApp.Areas.Store.Controllers
{
    public class DispatchAgencyController : Controller
    {
        private MiniAppEntities db = new MiniAppEntities();

        // GET: Store/DispatchAgency
        public ActionResult Index()
        {
            return View(db.DispatchAgencyTbls.ToList());
        }

        // GET: Store/DispatchAgency/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DispatchAgencyTbl dispatchAgencyTbl = db.DispatchAgencyTbls.Find(id);
            if (dispatchAgencyTbl == null)
            {
                return HttpNotFound();
            }
            return View(dispatchAgencyTbl);
        }

        // GET: Store/DispatchAgency/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/DispatchAgency/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DispatchAgencyID,DispatchAgencyName,Address,EmailID")] DispatchAgencyTbl dispatchAgencyTbl)
        {
            if (ModelState.IsValid)
            {
                db.DispatchAgencyTbls.Add(dispatchAgencyTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dispatchAgencyTbl);
        }

        // GET: Store/DispatchAgency/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DispatchAgencyTbl dispatchAgencyTbl = db.DispatchAgencyTbls.Find(id);
            if (dispatchAgencyTbl == null)
            {
                return HttpNotFound();
            }
            return View(dispatchAgencyTbl);
        }

        // POST: Store/DispatchAgency/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DispatchAgencyID,DispatchAgencyName,Address,EmailID")] DispatchAgencyTbl dispatchAgencyTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dispatchAgencyTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dispatchAgencyTbl);
        }

        // GET: Store/DispatchAgency/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DispatchAgencyTbl dispatchAgencyTbl = db.DispatchAgencyTbls.Find(id);
            if (dispatchAgencyTbl == null)
            {
                return HttpNotFound();
            }
            return View(dispatchAgencyTbl);
        }

        // POST: Store/DispatchAgency/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            DispatchAgencyTbl dispatchAgencyTbl = db.DispatchAgencyTbls.Find(id);
            db.DispatchAgencyTbls.Remove(dispatchAgencyTbl);
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
