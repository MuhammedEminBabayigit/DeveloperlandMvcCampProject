using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Developerland.UI.Controllers
{
    public class DraftController : Controller
    {
        // GET: Draft
        MessageManager mM = new MessageManager(new EfMessageDal());
        MessageValidator mV = new MessageValidator();
        public ActionResult Index()
        {
            var messages = mM.GetListDrafts();
            return View(messages);
        }
        //[HttpGet]
        //public ActionResult EditDraft(int id)
        //{
        //    var messageValues = mM.GetByID(id);
        //    return View(messageValues);
        //}

        //[HttpPost]
        //public ActionResult EditDraft(MEssa)
        //{
        //    var messageValues = mM.GetByID(id);
        //    return View(messageValues);
        //}
        public ActionResult DeleteMessageDraft(int id)
        {
            var messageValues = mM.GetByID(id);
            mM.MessageDelete(messageValues);
            return RedirectToAction("Index");
        }
    }
}