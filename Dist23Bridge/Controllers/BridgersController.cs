using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dist23Bridge.Models;

namespace Dist23Bridge.Controllers
{
    public class BridgersController : Controller
    {
        private BridgeData db = new BridgeData();

        // GET: Bridgers
        public ActionResult Index()
        {
            List<Bridgers> bridgers = db.Bridgers.ToList();
            foreach (Bridgers bridge in bridgers)
            {
                bridge.JailName = db.Jails.FirstOrDefault(x => x.jail_id == bridge.jail_id).JailName;
            }
            return View(bridgers);
        }

        // GET: Bridgers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bridgers bridger = db.Bridgers.Find(id);
            if (bridger == null)
            {
                return HttpNotFound();
            }
            return View(bridger);
        }

        // GET: Bridgers/Create
        public ActionResult Create()
        {
            ViewBag.jail_id = new SelectList(db.Jails, "jail_id", "JailName");
            return View();
        }

        // POST: Bridgers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bridgers bridger)
        {
            if (ModelState.IsValid)
            {
                db.Bridgers.Add(bridger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.jail_id = new SelectList(db.Jails, "jail_id", "JailName", bridger.jail_id);
            return View(bridger);
        }

        // GET: Bridgers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bridgers bridger = db.Bridgers.Find(id);
            if (bridger == null)
            {
                return HttpNotFound();
            }
            ViewBag.jail_id = new SelectList(db.Jails, "jail_id", "JailName", bridger.jail_id);
            return View(bridger);
        }

        // POST: Bridgers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bridgers bridger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bridger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.jail_id = new SelectList(db.Jails, "jail_id", "JailName", bridger.jail_id);
            return View(bridger);
        }

        // GET: Bridgers/Delete/5
        public ActionResult Delete(int? id)
        {
            Bridgers bridger = db.Bridgers.Find(id);
            db.Bridgers.Remove(bridger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Bridgers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

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
