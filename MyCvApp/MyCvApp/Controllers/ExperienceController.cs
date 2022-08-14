using MyCvApp.Models.Entity;
using MyCvApp.Repostitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCvApp.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceReposiyory repo = new ExperienceReposiyory();
        public ActionResult Index()
        {
            var values = repo.GetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Tbl_Experience p)
        {
            repo.Add(p);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Tbl_Experience t = repo.Find(x => x.ID == id);
            repo.Delete(t);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var experience = repo.Find(x => x.ID == id);
            return View(experience);
        }
        [HttpPost]
        public ActionResult Update(Tbl_Experience p)
        {
            Tbl_Experience t = repo.Find(x => x.ID == p.ID);
            t.Title = p.Title;
            t.Subtitle = p.Subtitle;
            t.Date = p.Date;
            t.Explanation = p.Explanation;
            repo.Update(t);
            return RedirectToAction("Index");
        }
    }
}