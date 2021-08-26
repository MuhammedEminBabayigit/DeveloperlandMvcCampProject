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
            ViewBag.SenderMailCount = ctx.Messages.Count(x => x.SenderMail == "admin@gmail.com" && x.IsDraft == false && x.IsRead == false);
            ViewBag.ReceiverMailCount = ctx.Messages.Count(x => x.ReceiverMail == "33ncPI39RDIN95CbCE2bZg==" && x.IsRead == false);
            ViewBag.DraftMailCount = ctx.Messages.Count(x => x.SenderMail == "admin@gmail.com" && x.IsDraft == true);
            ViewBag.ContactCount = cM.GetList().Count(x=>x.IsRead == false);
            return PartialView();
        }
        public ActionResult Activate(int id)
        {
            var contact = cM.GetByID(id);
            contact.IsRead = true;
            cM.ContactUpdate(contact);
            return RedirectToAction("Index");
        }
        public ActionResult Disable(int id)
        {
            var contact = cM.GetByID(id);
            contact.IsRead = false;
            cM.ContactUpdate(contact);
            return RedirectToAction("Index");
        }
    }
}