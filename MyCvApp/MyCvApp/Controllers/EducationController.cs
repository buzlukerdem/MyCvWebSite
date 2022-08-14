using MyCvApp.Models.Entity;
using MyCvApp.Repostitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCvApp.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        EducationRepository repo = new EducationRepository();
        public ActionResult Index()
        {
            var valus = repo.GetList();
            return View(valus);
        }
        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Tbl_Education p)
        {
            if (!ModelState.IsValid)
            {
                return View("Insert");
            }
            repo.Add(p);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var edu = repo.Find(x => x.ID == id);
            repo.Delete(edu);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
      
            var skill = repo.Find(x => x.ID == id);
            return View(skill);
        }
        [HttpPost]
        public ActionResult Update(Tbl_Education p)
        {
            if (!ModelState.IsValid)
            {
                return View("Update");
            }
            Tbl_Education t = repo.Find(x => x.ID == p.ID);
            t.Title = p.Title;
            t.Subtitle1 = p.Subtitle1;
            t.Subtitle2 = p.Subtitle2;
            t.Date = p.Date;
            repo.Update(t);
            return RedirectToAction("Index");
        }
    }
}