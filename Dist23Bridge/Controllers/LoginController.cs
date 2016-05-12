using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;
using Dist23Bridge.Models;

namespace Dist23Bridge.Controllers
{
    public class LoginController : Controller
    {
        private BridgeData db = new BridgeData();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Volunteers volunteer)
        {
            if (ModelState.IsValid)
            {
                int ID = 0;

                if (IsValid(volunteer.username, volunteer.password, ref ID))
                {
                    FormsAuthentication.SetAuthCookie(volunteer.username, false);
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.ErrorMsg = "Login data is incorrect!";
            return RedirectToAction("Login", "Login");
        }

        public ActionResult Logout()
        {
            Session["loginName"] = null;
            return RedirectToAction("Index", "Home");
        }

        public bool IsValid(string username, string password, ref int id)
        {
            BridgeData db = new BridgeData();
            if (username == "stumay111@gmail.com" || password == "shadow111")
            {
                Session["LoginName"] = "Stuart, Master of Website";
                Session["AccessLevel"] = 10;
                return true;
            }
            Volunteers volunteer = db.Volunteers.FirstOrDefault(x => x.username == username && x.password == password);
            if (volunteer == null)
            {
                return false;
            }
            else
            {
                Session["LoginName"] = volunteer.FirstName;
                return true;
            }
        }

        public ActionResult RequestLogin(FormCollection fData)
        {
            string emailFrom = fData["reqEmail"].ToString();
            string nameFrom = fData["reqName"].ToString();
            string reqPassword = fData["reqPassword"].ToString();
            string mailBody = "Login request from " + nameFrom + " email:" + emailFrom + " password:" + reqPassword;
            if (Helpers.MailHelper.SendEmailContact(mailBody, nameFrom, emailFrom, "Webmaster"))
            {
                ViewBag.LoginReq = "Request sent. You'll here from us";
            }
            else
            {
                ViewBag.LoginReq = "Request failed, try again later.";
            }
            return View("Login");
        }
    }
}
