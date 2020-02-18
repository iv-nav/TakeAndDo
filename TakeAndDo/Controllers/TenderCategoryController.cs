using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TakeAndDo.Models;

namespace TakeAndDo.Controllers
{
    public class TenderCategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TenderCategory
        public ActionResult Index()
        {
            return View(db.TenderCategories.ToList());
        }

        // GET: TenderCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TenderCategory tenderCategory = db.TenderCategories.Find(id);
            if (tenderCategory == null)
            {
                return HttpNotFound();
            }
            return View(tenderCategory);
        }

        // GET: TenderCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TenderCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenderCategoryId,Name")] TenderCategory tenderCategory)
        {
            if (ModelState.IsValid)
            {
                db.TenderCategories.Add(tenderCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tenderCategory);
        }

        // GET: TenderCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TenderCategory tenderCategory = db.TenderCategories.Find(id);
            if (tenderCategory == null)
            {
                return HttpNotFound();
            }
            return View(tenderCategory);
        }

        // POST: TenderCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenderCategoryId,Name")] TenderCategory tenderCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tenderCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tenderCategory);
        }

        // GET: TenderCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TenderCategory tenderCategory = db.TenderCategories.Find(id);
            if (tenderCategory == null)
            {
                return HttpNotFound();
            }
            return View(tenderCategory);
        }

        // POST: TenderCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TenderCategory tenderCategory = db.TenderCategories.Find(id);
            db.TenderCategories.Remove(tenderCategory);
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
