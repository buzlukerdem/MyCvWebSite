using MyCvApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyCvApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Tbl_Admin p)
        {
            DB_MyCVEntities db = new DB_MyCVEntities();
            var cookie = db.Tbl_Admin.FirstOrDefault(x=>x.Username==p.Username && x.Password == p.Password);
            if (cookie != null)
            {
                FormsAuthentication.SetAuthCookie(cookie.Username, false);
                Session["Username"] = cookie.Username.ToString();
                return RedirectToAction("Index", "About");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}