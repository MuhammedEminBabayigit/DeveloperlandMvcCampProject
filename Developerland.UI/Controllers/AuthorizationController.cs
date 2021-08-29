using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Developerland.UI.Models;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Developerland.UI.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDal());
        // GET: Authorization
        public ActionResult Index()
        {
            var adminValues = adm.GetList();
            foreach (var item in adminValues)
            {
                item.AdminEmail = Hashing.Descrypt(item.AdminEmail);
            }
            return View(adminValues);
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminValues = adm.GetByID(id);
            adminValues.AdminPassword = Hashing.Descrypt(adminValues.AdminPassword);
            adminValues.AdminEmail = Hashing.Descrypt(adminValues.AdminEmail);
            return View(adminValues);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            admin.AdminPassword = Hashing.Encrypt(admin.AdminPassword);
            admin.AdminEmail = Hashing.Encrypt(admin.AdminEmail);
            adm.AdminUpdate(admin);
            return RedirectToAction("Index");
        }
    }
}