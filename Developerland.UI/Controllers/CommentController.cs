using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Developerland.UI.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        CommentManager cM = new CommentManager(new EfCommentDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CommentByPost(int id)
        {
            var comments = cM.GetListByHeadingID(id);
            return View(comments);
        }
    }
}