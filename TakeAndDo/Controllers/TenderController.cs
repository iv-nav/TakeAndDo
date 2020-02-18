using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TakeAndDo.Models;
using TakeAndDo.Controllers;

namespace TakeAndDo.Controllers
{
    public class TenderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tender
        public ActionResult Index()
        {
            var tenders = db.Tenders.Include(t => t.Region).Include(t => t.Stock).Include(t => t.TenderCategory).Include(t => t.TenderType);
            return View(tenders.ToList());
        }

        // GET: Tender/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tender tender = db.Tenders.Find(id);
            if (tender == null)
            {
                return HttpNotFound();
            }
            return View(tender);
        }

        // GET: Tender/Create
        public ActionResult Create()
        {
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "Name");
            ViewBag.StockId = new SelectList(db.Stocks, "StockId", "Name");
            ViewBag.TenderCategoryId = new SelectList(db.TenderCategories, "TenderCategoryId", "Name");
            ViewBag.TenderTypeId = new SelectList(db.TenderTypes, "TenderTypeId", "Name");
            return View();
        }

        // POST: Tender/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Credits,Link,TenderTypeId,StockId,RegionId,TenderCategoryId,ExpirationDate,ParticipationDate,CompletionDate,InitMaxContractPrice,MinEstimatedPrice,VatIncludePrice,DeliveryPrice,ExtraCharge")] Tender tender)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Tenders.Add(tender);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException ex)
            {
                ModelState.AddModelError("", "Не удалось сохранить изменения.");
            }

            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "Name", tender.RegionId);
            ViewBag.StockId = new SelectList(db.Stocks, "StockId", "Name", tender.StockId);
            ViewBag.TenderCategoryId = new SelectList(db.TenderCategories, "TenderCategoryId", "Name", tender.TenderCategoryId);
            ViewBag.TenderTypeId = new SelectList(db.TenderTypes, "TenderTypeId", "Name", tender.TenderTypeId);
            return View(tender);
        }

        // GET: Tender/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tender tender = db.Tenders.Find(id);
            if (tender == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "Name", tender.RegionId);
            ViewBag.StockId = new SelectList(db.Stocks, "StockId", "Name", tender.StockId);
            ViewBag.TenderCategoryId = new SelectList(db.TenderCategories, "TenderCategoryId", "Name", tender.TenderCategoryId);
            ViewBag.TenderTypeId = new SelectList(db.TenderTypes, "TenderTypeId", "Name", tender.TenderTypeId);
            return View(tender);
        }

        // POST: Tender/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Credits,Link,TenderTypeId,StockId,RegionId,TenderCategoryId,ExpirationDate,ParticipationDate,CompletionDate,InitMaxContractPrice,MinEstimatedPrice,VatIncludePrice,DeliveryPrice,ExtraCharge")] Tender tender)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tender).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "Name", tender.RegionId);
            ViewBag.StockId = new SelectList(db.Stocks, "StockId", "Name", tender.StockId);
            ViewBag.TenderCategoryId = new SelectList(db.TenderCategories, "TenderCategoryId", "Name", tender.TenderCategoryId);
            ViewBag.TenderTypeId = new SelectList(db.TenderTypes, "TenderTypeId", "Name", tender.TenderTypeId);
            return View(tender);
        }

        // GET: Tender/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tender tender = db.Tenders.Find(id);
            if (tender == null)
            {
                return HttpNotFound();
            }
            return View(tender);
        }

        // POST: Tender/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tender tender = db.Tenders.Find(id);
            db.Tenders.Remove(tender);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void RedirectByLink(int? id)
        {
            if (id == null)
            {
                return;
            }

            Tender tender = db.Tenders.Find(id);

            if (tender != null)
                Response.Redirect(tender.Link);
        }

        [HttpGet]
        public ActionResult AddAgent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order order = new Order { TenderId = (int)id };
            ViewBag.AgentId = new SelectList(db.Agents, "AgentId", "Name");
            return View(order);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAgent(Order order)
        {

            if (order.TenderId <= 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            try
            {
                if (ModelState.IsValid)
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Не удалось сохранить изменения: " + ex.Message);                
            }

            return RedirectToAction("Edit", new { id = order.TenderId});
        }

        [HttpPost, ActionName("RemoveOrder")]
        public ActionResult RemoveOrder(int? id)
        {

            Order order = db.Orders.Find(id);

            if (order == null)
            {
                return HttpNotFound();
            }

            int tenderId = order.TenderId;

            try
            {
                if (ModelState.IsValid)
                {
                    db.Orders.Remove(order);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Не удалось сохранить изменения: " + ex.Message);
            }

            return RedirectToAction("Edit", new { id = tenderId });

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
