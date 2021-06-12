using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Developerland.UI.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        Context ctx = new Context();
        ContactManager cM = new ContactManager(new EfContactDal());

        ContactValidator cV = new ContactValidator();
        public ActionResult Index()
        {
            var contactValues = cM.GetList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = cM.GetByID(id);
            return View(contactValues);
        }
        public PartialViewResult SideBarContact()
        {
            ViewBag.SenderMailCount = ctx.Messages.Count(x => x.SenderMail == "admin@gmail.com" && x.IsDraft == false);
            ViewBag.ReceiverMailCount = ctx.Messages.Count(x => x.ReceiverMail == "admin@gmail.com");
            ViewBag.DraftMailCount = ctx.Messages.Count(x => x.SenderMail == "admin@gmail.com" && x.IsDraft == true);
            ViewBag.ContactCount = cM.GetList().Count;
            return PartialView();
        }
    }
}