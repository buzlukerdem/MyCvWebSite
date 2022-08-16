using MyCvApp.Models.Entity;
using MyCvApp.Repostitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCvApp.Controllers
{
    public class AdminController : Controller
    {
        AdminRepository repo = new AdminRepository();
        // GET: Admin
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
        public ActionResult Insert(Tbl_Admin p)
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
            Tbl_Admin t = repo.Find(x => x.ID == id);
            repo.Delete(t);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var admin = repo.Find(x => x.ID == id);
            return View(admin);
        }
        [HttpPost]
        public ActionResult Update(Tbl_Admin p)
        {
            Tbl_Admin t = repo.Find(x => x.ID == p.ID);
            t.Username = p.Username;
            t.Password = p.Password;
            repo.Update(t);
            return RedirectToAction("Index");
        }
    }
}