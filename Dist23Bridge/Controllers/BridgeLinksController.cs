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
            List<BridgeLinks> bridgeLinks = db.BridgeLinks.ToList();
            foreach (BridgeLinks link in bridgeLinks)
            {
                string fName = db.Bridgers.FirstOrDefault(x => x.bridge_id == link.bridge_id).FirstName;
                string lName = db.Bridgers.FirstOrDefault(x => x.bridge_id == link.bridge_id).LastName;
                link.BridgerName = fName + " " + lName;
                fName = db.Volunteers.FirstOrDefault(x => x.vol_id == link.vol_id).FirstName;
                lName = db.Volunteers.FirstOrDefault(x => x.vol_id == link.vol_id).LastName;
                link.VolName = fName + " " + lName;
            }
            return View(bridgeLinks);
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
            var bridgerList = db.Bridgers.ToList().Select(x => new
            {
                bridge_id = x.bridge_id,
                bridgeName = x.FirstName + " " + x.LastName
            });
            ViewBag.bridge_id = new SelectList(bridgerList, "bridge_id", "bridgeName");

            var volList = db.Volunteers.ToList().Select(x => new
            {
                vol_id = x.vol_id,
                volName = x.FirstName + " " + x.LastName
            });
            ViewBag.vol_id = new SelectList(volList, "vol_id", "volName");
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

            var bridgerList = db.Bridgers.ToList().Select(x => new
            {
                bridge_id = x.bridge_id,
                bridgeName = x.FirstName + " " + x.LastName
            });
            ViewBag.bridge_id = new SelectList(bridgerList, "bridge_id", "bridgeName");

            var volList = db.Volunteers.ToList().Select(x => new
            {
                vol_id = x.vol_id,
                volName = x.FirstName + " " + x.LastName
            });
            ViewBag.vol_id = new SelectList(volList, "vol_id", "volName");
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
            var bridgerList = db.Bridgers.ToList().Select(x => new
            {
                bridge_id = x.bridge_id,
                bridgeName = x.FirstName + " " + x.LastName
            });
            ViewBag.bridge_id = new SelectList(bridgerList, "bridge_id", "bridgeName");
            foreach(var item in ViewBag.bridge_id)
            {
                if (item.Value == bridgeLink.bridge_id.ToString())
                {
                    item.Selected = true;
                    break;
                }
            }


            var volList = db.Volunteers.ToList().Select(x => new
            {
                vol_id = x.vol_id,
                volName = x.FirstName + " " + x.LastName
            });
            ViewBag.vol_id = new SelectList(volList, "vol_id", "volName");
            foreach (var item in ViewBag.vol_id)
            {
                if (item.Value == bridgeLink.vol_id.ToString())
                {
                    item.Selected = true;
                    break;
                }
            }
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
            var bridgerList = db.Bridgers.ToList().Select(x => new
            {
                bridge_id = x.bridge_id,
                bridgeName = x.FirstName + " " + x.LastName
            });
            ViewBag.bridge_id = new SelectList(bridgerList, "bridge_id", "bridgeName");

            var volList = db.Volunteers.ToList().Select(x => new
            {
                vol_id = x.vol_id,
                volName = x.FirstName + " " + x.LastName
            });
            ViewBag.vol_id = new SelectList(volList, "vol_id", "volName");
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
