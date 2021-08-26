using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Developerland.UI.Models;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Developerland.UI.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        Context ctx = new Context();
        MessageManager mM = new MessageManager(new EfMessageDal());
        MessageValidator mV = new MessageValidator();
        WriterManager wM = new WriterManager(new EfWriterDal());
        public ActionResult Inbox(string p)
        {
            p = (string)Session["WriterNickName"];
            var writerMailInfo = wM.GetByNickName(p).WriterEmail;
            var messageValues = mM.GetListInbox(writerMailInfo);
            return View(messageValues);
        }
        public ActionResult Sendbox(string p)
        {
            p = (string)Session["WriterNickName"];
            var writerMailInfo = wM.GetByNickName(p).WriterEmail;
            var messageValues = mM.GetListSendbox(writerMailInfo);
            foreach (var item in messageValues)
            {
                item.ReceiverMail = Hashing.Descrypt(item.ReceiverMail);
                }
            return View(messageValues);
        }
        public PartialViewResult MessageListMenu(string p)
        {
            p = (string)Session["WriterNickName"];
            var writerMailInfo = wM.GetByNickName(p).WriterEmail;
            ViewBag.SenderMailCount = ctx.Messages.Count(x => x.SenderMail == writerMailInfo && x.IsDraft == false && x.IsRead == false);
            ViewBag.ReceiverMailCount = ctx.Messages.Count(x => x.ReceiverMail == writerMailInfo && x.IsRead == false);
            ViewBag.DraftMailCount = ctx.Messages.Count(x => x.SenderMail == writerMailInfo && x.IsDraft == true);
            return PartialView();
        }


        public ActionResult GetSendboxDetails(int id)
        {
            var messageValues = mM.GetByID(id);
            return View(messageValues);
        }
        public ActionResult GetInboxDetails(int id)
        {
            var messageValues = mM.GetByID(id);
            messageValues.IsRead = true;
            mM.MessageUpdate(messageValues);
            return View(messageValues);
        }

        [HttpGet]
        public ActionResult NewMessage(params int[] id)
        {
            if (id != null)
            {
                var messagevalues = mM.GetByID(id[0]);
                return View(messagevalues);

            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewMessage(Message message, string parameter)
        {
            ValidationResult results = mV.Validate(message);
            string p = (string)Session["WriterNickName"];
            if (parameter == "send")
            {
                if (results.IsValid)
                {
                    message.SenderMail = wM.GetByNickName(p).WriterEmail;
                    message.IsDraft = false;
                    message.MessageDate = DateTime.Now;
                    mM.AddMessage(message);
                    message.ReceiverMail = Hashing.Encrypt(message.ReceiverMail);
                    mM.MessageUpdate(message);
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (parameter == "draft")
            {
                if (results.IsValid)
                {
                    message.SenderMail = wM.GetByNickName(p).WriterEmail;
                    message.IsDraft = true;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mM.AddMessage(message);
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }

            return View();
        }
    }
}