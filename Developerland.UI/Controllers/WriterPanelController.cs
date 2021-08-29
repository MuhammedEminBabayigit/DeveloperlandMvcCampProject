using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules.FluentValidation;

namespace Developerland.UI.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        PostManager pM = new PostManager(new EfPostDal());
        CategoryManager cM = new CategoryManager(new EfCategoryDal());
        WriterManager wM = new WriterManager(new EfWriterDal());
        CommentManager coM = new CommentManager(new EfCommentDal());
        UserCommentManager ucM = new UserCommentManager(new EfUserCommentDal());
        WriterValidator wV = new WriterValidator();
        [HttpGet]
        public ActionResult WriterProfile(/*int id*/)
        {
            string p = (string)Session["WriterNickName"];
            int id = wM.GetByNickName(p).WriterID;
            var writerValue = wM.GetByID(id);
            return View(writerValue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            ValidationResult results = wV.Validate(p);
            if (results.IsValid)
            {
                p.Updated = DateTime.Now;
                wM.WriterUpdate(p);
                return RedirectToAction("WriterProfile");
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
        public ActionResult MyPost(string parameter/*, int? page = 1*/)
        {
            int id;
            string p = (string)Session["WriterNickName"];
            id = wM.GetByNickName(p).WriterID;
            var values = pM.GetListByWriter(id);
            //var values = pM.GetListByWriter(id).ToPagedList(page ?? 1, 4);
            if (!string.IsNullOrEmpty(parameter))
            {
               values = pM.GetListByWriterAndFilter(id, parameter);
               //values = pM.GetListByWriterAndFilter(id, parameter).ToPagedList(page ?? 1, 4);
            }
            return View(values);
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
            ViewBag.valueCategory = _valueCategory;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddPost(Post p)
        {
            string writerMailInfo = (string)Session["WriterNickName"];
            var writeridinfo = wM.GetByNickName(writerMailInfo).WriterID;
            p.PostDate = DateTime.Now;
            p.WriterID = writeridinfo;
            p.PostStatus = true;
            pM.AddPost(p);
            return RedirectToAction("MyPost");
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
        [ValidateInput(false)]
        public ActionResult EditPost(Post p)
        {
            pM.UpdatePost(p);
            return RedirectToAction("MyPost");
        }
        public ActionResult DeletePost(int id)
        {
            var post = pM.GetByID(id);
            post.PostStatus = false;
            pM.DeletePost(post);
            return RedirectToAction("MyPost");
        }
        public ActionResult ActivePost(int id)
        {
            var post = pM.GetByID(id);
            post.PostStatus = true;
            pM.ActivePost(post);
            return RedirectToAction("MyPost");
        }
        public ActionResult CommentsPartial(int id)
        {
            var comments = coM.GetListByHeadingID(id);
            return View(comments);
        }
        public PartialViewResult UserCommentPartial(int id)
        {
            var userComments = ucM.GetListByPostID(id);
            return PartialView(userComments);
        }
    }
}