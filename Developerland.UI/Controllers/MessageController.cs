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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mM = new MessageManager(new EfMessageDal());
        MessageValidator mV = new MessageValidator();
        AdminManager adm = new AdminManager(new EfAdminDal());
        [Authorize(Roles ="B")]
        public ActionResult Inbox(string parameter)
        {
            parameter = (string)Session["AdminNickName"];
            var adminMailInfo = adm.GetByNickname(parameter).AdminEmail;
            var messageValues = mM.GetListInbox(adminMailInfo);
            return View(messageValues);
        }
        public ActionResult Sendbox(string p)
        {
            p = (string)Session["AdminNickName"];
            var adminMailInfo = adm.GetByNickname(p).AdminEmail;
            var messageValues = mM.GetListSendbox(adminMailInfo);
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
        public ActionResult NewMessage(Message message,string parameter)
        {
            ValidationResult results = mV.Validate(message);
            if (parameter == "send")
            {
                if (results.IsValid)
                {
                    message.SenderMail = "admin@gmail.com";
                    message.IsDraft = false;
                    message.MessageDate = DateTime.Now;
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
            else if (parameter == "draft")
            {
                if (results.IsValid)
                {
                    message.SenderMail = "admin@gmail.com";
                    message.IsDraft = true;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mM.AddMessage(message);
                    return RedirectToAction("Index","Draft");
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
        public ActionResult DeleteMessageSendbox(int id)
        {
            var messageValues = mM.GetByID(id);
            mM.MessageDelete(messageValues);
            return RedirectToAction("Sendbox");
        }
        public ActionResult DeleteMessageInbox(int id)
        {
            var messageValues = mM.GetByID(id);
            mM.MessageDelete(messageValues);
            return RedirectToAction("Inbox");
        }

        public ActionResult Activate(int id)
        {
            var message = mM.GetByID(id);
            message.IsRead = true;
            mM.MessageUpdate(message);
            return RedirectToAction("Inbox");
        }
        public ActionResult Disable(int id)
        {
            var message = mM.GetByID(id);
            message.IsRead = false;
            mM.MessageUpdate(message);
            return RedirectToAction("Inbox");
        }
    }
}