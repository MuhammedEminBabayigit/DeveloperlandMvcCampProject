using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
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
    public class AdminWriterController : Controller
    {
        // GET: AdminWriter
        WriterManager wM = new WriterManager(new EfWriterDal());
        WriterValidator wV = new WriterValidator();
        public ActionResult Index()
        {
            var writerValues = wM.GetList();
            return View(writerValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {

            ValidationResult results = wV.Validate(writer);
            if (results.IsValid)
            {
                writer.WriterEmail = Hashing.Encrypt(writer.WriterEmail);
                writer.WriterPassword = Hashing.Encrypt(writer.WriterPassword);
                writer.Created = DateTime.Now;
                wM.WriterAdd(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteWriter(int id)
        {
            var writerValue = wM.GetByID(id);
            wM.WriterDelete(writerValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writerValue = wM.GetByID(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {
            ValidationResult results = wV.Validate(p);
            if (results.IsValid)
            {
                p.Updated = DateTime.Now;
                wM.WriterUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}