using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Developerland.UI.Controllers
{
    public class AdminPostController : Controller
    {
        // GET: AdminPost
        PostManager pM = new PostManager(new EfPostDal());
        CategoryManager cM = new CategoryManager(new EfCategoryDal());
        WriterManager wM = new WriterManager(new EfWriterDal());
        public ActionResult Index(int sayfa = 1)
        { 
            var postValues = pM.GetList().ToPagedList(sayfa,4);
            return View(postValues);
        }

        [HttpGet]
        public ActionResult AddPost()
        {
            List<SelectListItem> _valueCategory = (from x in cM.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            List<SelectListItem> _writerCategory = (from x in wM.GetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.WriterFullName,
                                                        Value = x.WriterID.ToString()
                                                    }).ToList();
            ViewBag.valueCategory = _valueCategory;
            ViewBag.valueWriter = _writerCategory;
            return View();
        }

        [HttpPost]
        public ActionResult AddPost(Post p)
        {
            p.PostDate = DateTime.Now;
            pM.AddPost(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditPost(int id)
        {
            List<SelectListItem> _valueCategory = (from x in cM.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.valueCategory = _valueCategory;
            var post = pM.GetByID(id);
            return View(post);
        }

        [HttpPost]
        public ActionResult EditPost(Post p)
        {
            pM.UpdatePost(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeletePost(int id)
        {
            var post = pM.GetByID(id);
            post.PostStatus = false;
            pM.DeletePost(post);
            return RedirectToAction("Index");

        }
        public ActionResult ActivePost(int id)
        {
            var post = pM.GetByID(id);
            post.PostStatus = true;
            pM.ActivePost(post);
            return RedirectToAction("Index");

        }
    }
}