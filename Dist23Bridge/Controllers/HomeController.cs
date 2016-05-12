using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dist23Bridge.Models;

namespace Dist23Bridge.Controllers
{
    public class HomeController : Controller
    {
        // GET: Jails
        public ActionResult Index()
        {
            using (BridgeData db = new BridgeData())
            {
                //return View(db.Jails.Where(x => x.jail_id != 2).ToList());
                return View(db.Jails.ToList());
            }
        }
    }
}