using MyCvApp.Models.Entity;
using MyCvApp.Repostitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCvApp.Controllers
{
    public class SkillsController : Controller
    {
        SkillsRepository repo = new SkillsRepository();

        // GET: Skills
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
        public ActionResult Insert(Tbl_MySkills p)
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
            var skill  = repo.Find(x => x.ID == id);
            repo.Delete(skill);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var skill = repo.Find(x => x.ID == id);
            return View(skill);
        }
        [HttpPost]
        public ActionResult Update(Tbl_MySkills p)
        {
            Tbl_MySkills t = repo.Find(x => x.ID == p.ID);
            t.MySkills = p.MySkills;
            t.Puan = p.Puan;
            repo.Update(t);
            return RedirectToAction("Index");
        }
    }
}