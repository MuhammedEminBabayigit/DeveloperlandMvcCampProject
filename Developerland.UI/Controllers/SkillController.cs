using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Developerland.UI.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        SkillManager sM = new SkillManager(new EfSkillDal());
        public ActionResult Index()
        {
            var skills = sM.GetList();
            return View(skills);
        }
    }
}