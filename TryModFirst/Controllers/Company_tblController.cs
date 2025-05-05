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
    public class Company_tblController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Company_tbl
        public ActionResult Index()
        {
            return View(db.Company_tbl.ToList());
        }

        // GET: Company_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_tbl company_tbl = db.Company_tbl.Find(id);
            if (company_tbl == null)
            {
                return HttpNotFound();
            }
            return View(company_tbl);
        }

        // GET: Company_tbl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company_tbl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Age,Gender")] Company_tbl company_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Company_tbl.Add(company_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(company_tbl);
        }

        // GET: Company_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_tbl company_tbl = db.Company_tbl.Find(id);
            if (company_tbl == null)
            {
                return HttpNotFound();
            }
            return View(company_tbl);
        }

        // POST: Company_tbl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Age,Gender")] Company_tbl company_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company_tbl);
        }

        // GET: Company_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_tbl company_tbl = db.Company_tbl.Find(id);
            if (company_tbl == null)
            {
                return HttpNotFound();
            }
            return View(company_tbl);
        }

        // POST: Company_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company_tbl company_tbl = db.Company_tbl.Find(id);
            db.Company_tbl.Remove(company_tbl);
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
