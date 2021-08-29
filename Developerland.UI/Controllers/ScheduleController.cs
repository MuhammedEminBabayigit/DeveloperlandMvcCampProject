using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Developerland.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Developerland.UI.Controllers
{
    public class ScheduleController : Controller
    {
      
        PostManager pM = new PostManager(new EfPostDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View(new Calendar());
        }

        public JsonResult GetEvents(DateTime start, DateTime end)
        {
            var viewModel = new Calendar();
            var events = new List<Calendar>();
            start = DateTime.Today.AddDays(-14);
            end = DateTime.Today.AddDays(-14);

            foreach (var item in pM.GetList())
            {
                events.Add(new Calendar()
                {
                    title = item.PostHead,
                    start =item.PostDate,
                    end = item.PostDate.AddDays(-14),
                    allDay = false
                });

                start = start.AddDays(7);
                end = end.AddDays(7);
            }


            return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
        }

    }
}