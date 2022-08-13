using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCvApp.Models.Entity;

namespace MyCvApp.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        DB_MyCVEntities db = new DB_MyCVEntities();
        public ActionResult Index()
        {
            var values = db.Tbl_About.ToList();
            return View(values);
        }
        public PartialViewResult Experience()
        {
            var experience = db.Tbl_Experience.ToList();
            return PartialView(experience);
        }
        public PartialViewResult Education()
        {
            var education = db.Tbl_Education.ToList();
            return PartialView(education);
        }
        public PartialViewResult Skills()
        {
            var mySkills = db.Tbl_MySkills.ToList();
            return PartialView(mySkills);
        }
        public PartialViewResult Certificate()
        {
            var certificate = db.Tbl_Certificate.ToList();
            return PartialView(certificate);
        }
        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(Tbl_Contact c)
        {
            c.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbl_Contact.Add(c);
            db.SaveChanges();
            return PartialView();
        }
    }
}