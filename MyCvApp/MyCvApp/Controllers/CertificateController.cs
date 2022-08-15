using MyCvApp.Models.Entity;
using MyCvApp.Repostitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCvApp.Controllers
{
    public class CertificateController : Controller
    {
        // GET: Certificate
        CertificateRepository repo = new CertificateRepository();

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
        public ActionResult Insert(Tbl_Certificate p)
        {
            if (!ModelState.IsValid)
            {
                return View("Insert");
            }
            repo.Add(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var certificate = repo.Find(x => x.ID == id);
            return View(certificate);
        }
        [HttpPost]
        public ActionResult Update(Tbl_Certificate t)
        {
            var certificate = repo.Find(x => x.ID == t.ID);
            certificate.Explanation = t.Explanation;
            certificate.Date = t.Date;
            repo.Update(certificate);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var cert = repo.Find(x => x.ID == id);
            repo.Delete(cert);
            return RedirectToAction("Index");   
        }
    }
}