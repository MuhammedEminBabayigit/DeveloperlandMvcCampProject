using Developerland.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Developerland.UI.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        public List<Category> BlogList()
        {
            List<Category> ct = new List<Category>();
            ct.Add(new Category
            {
                 CategoryCount = 8,
                  CategoryName ="Yazilim"
            });
            ct.Add(new Category
            {
                CategoryCount = 6,
                CategoryName = "Seyehat"
            });
            ct.Add(new Category
            {
                CategoryCount = 4,
                CategoryName = "Teknoloji"
            });
            ct.Add(new Category
            {
                CategoryCount = 7,
                CategoryName = "Spor"
            });
            return ct;

        }
    }
}