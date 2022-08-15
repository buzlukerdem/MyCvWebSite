using MyCvApp.Repostitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCvApp.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactRepository repo = new ContactRepository();
        public ActionResult Index()
        {
            var c = repo.GetList();
            return View(c);
        }
    }
}