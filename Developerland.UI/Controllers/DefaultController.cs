using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Developerland.UI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        PostManager pM = new PostManager(new EfPostDal());
        CommentManager cM = new CommentManager(new EfCommentDal());
        public ActionResult Headings()
        {
            var postList = pM.GetList();
            return View(postList);
        }
        public PartialViewResult Index(int id = 1)
        {
            var post = pM.GetByID(id);
            ViewBag.PostSayisi = pM.GetListByWriter((int)post.WriterID).Count;
            return PartialView(post);
        }

        public PartialViewResult Comments(int id = 1)
        {
            var post = pM.GetByID(id);
            var comments = cM.GetListByHeadingID(post.PostID);
            
            return PartialView(comments);
        }
    }
}