using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dist23Bridge.Controllers
{
    public class HomeController : Controller
    {
        // GET: Jails
        public ActionResult Index()
        {
            using (Dist23BridgeEntities db = new Dist23BridgeEntities())
            {
                return View(db.Jails.ToList());
            }
        }
    }
}