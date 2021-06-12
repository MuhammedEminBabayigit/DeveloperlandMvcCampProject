using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Developerland.UI.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        WriterManager wM = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var writerValues = wM.GetList();
            return View(writerValues);
        }
    }
}