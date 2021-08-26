using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Developerland.UI.Controllers
{
    public class WriterPanelCommentController : Controller
    {
        // GET: WriterPanelComment
        //yazarın commentlerini getireceksin 
        PostManager pM = new PostManager(new EfPostDal());
        WriterManager wM = new WriterManager(new EfWriterDal());
        UserCommentManager ucm = new UserCommentManager(new EfUserCommentDal());
        MessageManager mM = new MessageManager(new EfMessageDal());
        AdminManager adm = new AdminManager(new EfAdminDal());
        //Add comment devam
        public ActionResult Index()
        {
            string writerMailInfo = (string)Session["WriterNickName"];
            var writerIdInfo = wM.GetByNickName(writerMailInfo).WriterID;
            var comments = ucm.GetListByWriterID(writerIdInfo);
            return View(comments);
        }
        public ActionResult GetDeletedComment()
        {
            string writerMailInfo = (string)Session["WriterNickName"];
            var writerIdInfo = wM.GetByNickName(writerMailInfo).WriterID;
            var comments = ucm.GetListByWriterIDByFalse(writerIdInfo);
            return View(comments);
        }
        public ActionResult DeleteComment(int id)
        {
            var comment = ucm.GetByID(id);
            comment.CommentStatus = false;
            ucm.UpdateComment(comment);
            return RedirectToAction("Index");
        }

        public ActionResult RequestToBeActive(int id)
        {
            string writerMailInfo = (string)Session["WriterNickName"];
            var writerMail = wM.GetByNickName(writerMailInfo).WriterEmail;
            var adminMail = adm.GetList().First().AdminEmail;
            var comment = ucm.GetByID(id);
            Message message = new Message()
            { IsDraft = false,
                IsRead = false,
                 MessageContent ="Tarafımca oluşturulmuş " + comment.Post.PostHead +" gönderisine ait " + comment.CommentID+" ID'sine sahip yorumumun aktifleşmesini talep ediyorum." ,
                  MessageDate = DateTime.Now,
                   MessageSubject = "Yorum Aktifleştirme Talebi",
                    ReceiverMail = adminMail,
                     SenderMail=writerMail
            };
            mM.AddMessage(message);
            return RedirectToAction("GetDeletedComment");
        }
        [HttpGet]
        public ActionResult AddComment(int id)
        {
            var post = pM.GetByID(id);
            ViewBag.PostId = post.PostID;
            return View();
        }
        //Bura tamamlanacak
        [HttpPost]
        public ActionResult AddComment(UserComment p)
        {
            string writerMailInfo = (string)Session["WriterNickName"];
            var writerId = wM.GetByNickName(writerMailInfo).WriterID;
            p.WriterID = writerId;
            p.CommentStatus = false;
            p.CommentDate = DateTime.Now;
            ucm.AddComment(p);
            return RedirectToAction("Headings", "Default");
        }
    }
}