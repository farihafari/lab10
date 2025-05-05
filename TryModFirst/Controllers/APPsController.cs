using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TryModFirst.Models;

namespace TryModFirst.Controllers
{
    public class APPsController : Controller
    {
        private Model2Container db = new Model2Container();

        // GET: APPs
        public ActionResult Index()
        {
            return View(db.APPs.ToList());
        }

        // GET: APPs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP aPP = db.APPs.Find(id);
            if (aPP == null)
            {
                return HttpNotFound();
            }
            return View(aPP);
        }

        // GET: APPs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: APPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] APP aPP)
        {
            if (ModelState.IsValid)
            {
                db.APPs.Add(aPP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aPP);
        }

        // GET: APPs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP aPP = db.APPs.Find(id);
            if (aPP == null)
            {
                return HttpNotFound();
            }
            return View(aPP);
        }

        // POST: APPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] APP aPP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aPP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aPP);
        }

        // GET: APPs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP aPP = db.APPs.Find(id);
            if (aPP == null)
            {
                return HttpNotFound();
            }
            return View(aPP);
        }

        // POST: APPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            APP aPP = db.APPs.Find(id);
            db.APPs.Remove(aPP);
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
