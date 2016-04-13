using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dist23Bridge;

namespace Dist23Bridge.Controllers
{
    public class BridgersController : Controller
    {
        private Dist23BridgeEntities db = new Dist23BridgeEntities();

        // GET: Bridgers
        public ActionResult Index()
        {
            var bridgers = db.Bridgers.Include(b => b.Jail);
            return View(bridgers.ToList());
        }

        // GET: Bridgers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bridger bridger = db.Bridgers.Find(id);
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
        public ActionResult Create([Bind(Include = "bridge_id,FirstName,LastName,City,Phone,InmateID,jail_id,ReleaseDate")] Bridger bridger)
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
            Bridger bridger = db.Bridgers.Find(id);
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
        public ActionResult Edit([Bind(Include = "bridge_id,FirstName,LastName,City,Phone,InmateID,jail_id,ReleaseDate")] Bridger bridger)
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bridger bridger = db.Bridgers.Find(id);
            if (bridger == null)
            {
                return HttpNotFound();
            }
            return View(bridger);
        }

        // POST: Bridgers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bridger bridger = db.Bridgers.Find(id);
            db.Bridgers.Remove(bridger);
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
