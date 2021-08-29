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
    public class SkillController : Controller
    {
        // GET: Skill
        SkillManager sM = new SkillManager(new EfSkillDal());
        public ActionResult Index()
        {
            var skills = sM.GetList();
            return View(skills);
        }
        public ActionResult SkillManager()
        {
            var skills = sM.GetList();
            return View(skills);
        }
        [HttpGet]
        public ActionResult AddTalent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTalent(Skill talent)
        {
            sM.AddSkill(talent);
            return RedirectToAction("SkillManager");
        }
        [HttpGet]
        public ActionResult EditTalent(int id)
        {
            var result = sM.GetByID(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult EditTalent(Skill talent)
        {
            sM.UpdateSkill(talent);
            return RedirectToAction("SkillManager");
        }
        public ActionResult DeleteTalent(int Id)
        {
            var result = sM.GetByID(Id);
            sM.DeleteSkill(result);
            return RedirectToAction("SkillManager");
        }
    }
}