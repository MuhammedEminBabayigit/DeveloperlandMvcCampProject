using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Developerland.UI.Controllers
{
    public class AdminAboutController : Controller
    {
        // GET: AdminAbout
        AboutManager aM = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutValues = aM.GetList();
            return View(aboutValues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            aM.AddAbout(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
        public ActionResult Activate(int id)
        {
            var activeAbout = aM.GetActiveAbout();
            activeAbout.IsActive = false;
            aM.AboutUpdate(activeAbout);
            var about = aM.GetByID(id);
            about.IsActive = true;
            aM.AboutUpdate(about);
            return RedirectToAction("Index");
        }
        
    }
}