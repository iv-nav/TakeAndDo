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
    public class TenderTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TenderType
        public ActionResult Index()
        {
            return View(db.TenderTypes.ToList());
        }

        // GET: TenderType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TenderType tenderType = db.TenderTypes.Find(id);
            if (tenderType == null)
            {
                return HttpNotFound();
            }
            return View(tenderType);
        }

        // GET: TenderType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TenderType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenderTypeId,Name")] TenderType tenderType)
        {
            if (ModelState.IsValid)
            {
                db.TenderTypes.Add(tenderType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tenderType);
        }

        // GET: TenderType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TenderType tenderType = db.TenderTypes.Find(id);
            if (tenderType == null)
            {
                return HttpNotFound();
            }
            return View(tenderType);
        }

        // POST: TenderType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenderTypeId,Name")] TenderType tenderType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tenderType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tenderType);
        }

        // GET: TenderType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TenderType tenderType = db.TenderTypes.Find(id);
            if (tenderType == null)
            {
                return HttpNotFound();
            }
            return View(tenderType);
        }

        // POST: TenderType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TenderType tenderType = db.TenderTypes.Find(id);
            db.TenderTypes.Remove(tenderType);
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
