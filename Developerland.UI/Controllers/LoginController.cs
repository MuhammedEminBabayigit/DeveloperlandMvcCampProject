using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Developerland.UI.Models;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Developerland.UI.Controllers
{
    public class LoginController : Controller
    {
        AdminManager adM = new AdminManager(new EfAdminDal());
        WriterManager wM = new WriterManager(new EfWriterDal());
        // GET: Login
        //[HttpGet]
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Index(Admin p)
        //{
        //    p.AdminPassword = Hashing.Encrypt(p.AdminPassword);
        //    var adminUserInfo = adM.GetByNicknameAndPassword(p);
        //    if (adminUserInfo != null)
        //    {
        //        FormsAuthentication.SetAuthCookie(adminUserInfo.AdminNickName,false);
        //        Session["AdminNickName"] = adminUserInfo.AdminNickName;
        //        return RedirectToAction("Index", "AdminCategory");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index");
        //    }

        //}

        //public ActionResult LogOut()
        //{
        //    FormsAuthentication.SignOut();
        //    return RedirectToAction("Index", "Login");
        //}
        [HttpGet]
        [AllowAnonymous]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult WriterLogin(Writer p)
        {
            p.WriterPassword = Hashing.Encrypt(p.WriterPassword);
            var writerInfo = wM.GetByUsernameAndPassword(p);
            if (writerInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerInfo.WriterNickName, false);
                Session["WriterNickName"] = writerInfo.WriterNickName;
                //return RedirectToAction("MyPost", "WriterPanel");
                return RedirectToAction("MyPost", "WriterPanel");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "WriterLogin");
        }
    }
}