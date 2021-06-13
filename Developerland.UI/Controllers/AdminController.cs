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
using System.Web.Security;

namespace Developerland.UI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        AdminManager adM = new AdminManager(new EfAdminDal());
        AdminValidator aV = new AdminValidator();

        [Authorize(Roles = "B")]
        public ActionResult Index()
        {
            var adminValues = adM.GetList();
            foreach (var item in adminValues)
            {
                item.AdminEmail = Hashing.Descrypt(item.AdminEmail);
            }
            return View(adminValues);
        }

        [HttpGet]
        [Authorize(Roles = "B")]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            ValidationResult results = aV.Validate(admin);
            
            if (results.IsValid)
            {
                admin.AdminEmail = Hashing.Encrypt(admin.AdminEmail);
                admin.AdminPassword = Hashing.Encrypt(admin.AdminPassword);
                adM.AddAdmin(admin);
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

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin p)
        {
            p.AdminPassword = Hashing.Encrypt(p.AdminPassword);
            var adminUserInfo = adM.GetByNicknameAndPassword(p);
            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminNickName, false);
                Session["AdminNickName"] = adminUserInfo.AdminNickName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Admin");
        }
    }
}