using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dist23Bridge;
using Dist23Bridge.Models;

namespace Dist23Bridge.Controllers
{
    public class BridgeLinksController : Controller
    {
        private BridgeData db = new BridgeData();

        // GET: BridgeLinks
        public ActionResult Index()
        {
            var bridgeLinks = db.BridgeLinks;
            return View(bridgeLinks.ToList());
        }

        // GET: BridgeLinks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BridgeLinks bridgeLink = db.BridgeLinks.Find(id);
            if (bridgeLink == null)
            {
                return HttpNotFound();
            }
            return View(bridgeLink);
        }

        // GET: BridgeLinks/Create
        public ActionResult Create()
        {
            ViewBag.bridge_id = new SelectList(db.Bridgers, "bridge_id", "FirstName");
            ViewBag.vol_id = new SelectList(db.Volunteers, "vol_id", "FirstName");
            return View();
        }

        // POST: BridgeLinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BridgeLinks bridgeLink)
        {
            if (ModelState.IsValid)
            {
                db.BridgeLinks.Add(bridgeLink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.vol_id = new SelectList(db.Bridgers, "bridge_id", "FirstName", bridgeLink.vol_id);
            ViewBag.vol_id = new SelectList(db.Volunteers, "vol_id", "FirstName", bridgeLink.vol_id);
            return View(bridgeLink);
        }

        // GET: BridgeLinks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BridgeLinks bridgeLink = db.BridgeLinks.Find(id);
            if (bridgeLink == null)
            {
                return HttpNotFound();
            }
            ViewBag.vol_id = new SelectList(db.Bridgers, "bridge_id", "FirstName", bridgeLink.vol_id);
            ViewBag.vol_id = new SelectList(db.Volunteers, "vol_id", "FirstName", bridgeLink.vol_id);
            return View(bridgeLink);
        }

        // POST: BridgeLinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BridgeLinks bridgeLink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bridgeLink).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.vol_id = new SelectList(db.Bridgers, "bridge_id", "FirstName", bridgeLink.vol_id);
            ViewBag.vol_id = new SelectList(db.Volunteers, "vol_id", "FirstName", bridgeLink.vol_id);
            return View(bridgeLink);
        }

        // GET: BridgeLinks/Delete/5
        public ActionResult Delete(int? id)
        {
            BridgeLinks bridgeLink = db.BridgeLinks.Find(id);
            db.BridgeLinks.Remove(bridgeLink);
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
