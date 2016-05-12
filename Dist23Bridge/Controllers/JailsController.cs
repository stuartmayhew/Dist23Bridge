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
    public class JailsController : Controller
    {
        private BridgeData db = new BridgeData();

        // GET: Jails
        public ActionResult Index()
        {
            return View(db.Jails.ToList());
        }

        // GET: Jails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jails jail = db.Jails.Find(id);
            if (jail == null)
            {
                return HttpNotFound();
            }
            return View(jail);
        }

        // GET: Jails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Jails jail)
        {
            if (ModelState.IsValid)
            {
                db.Jails.Add(jail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jail);
        }

        // GET: Jails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jails jail = db.Jails.Find(id);
            if (jail == null)
            {
                return HttpNotFound();
            }
            return View(jail);
        }

        // POST: Jails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Jails jail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jail);
        }

        // GET: Jails/Delete/5
        public ActionResult Delete(int? id)
        {
            Jails jail = db.Jails.Find(id);
            db.Jails.Remove(jail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Jails/Delete/5

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
