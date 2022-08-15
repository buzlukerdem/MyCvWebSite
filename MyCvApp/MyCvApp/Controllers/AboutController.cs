using MyCvApp.Models.Entity;
using MyCvApp.Repostitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCvApp.Controllers
{
    public class AboutController : Controller
    {
        AboutRepository repo = new AboutRepository();
        // GET: About
        [HttpGet]
        public ActionResult Index()
        {
            var values = repo.GetList();
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(Tbl_About t)
        {
            var value = repo.Find(x => x.ID == 1);
            value.Name = t.Name;
            value.Surname = t.Surname;
            value.Address = t.Address;
            value.PhoneNumber = t.PhoneNumber;
            value.Explanation = t.Explanation;
            value.Picture = t.Picture;
            repo.Update(value);
            return RedirectToAction("Index");
        }
    }
}