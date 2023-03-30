using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProje.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        SkillManager sm = new SkillManager(new EfSkillDal());
        public ActionResult Index()
        {
            var skillvalues = sm.GetList();
            return View(skillvalues);
        }
        public ActionResult SkillView()
        {
            var skillvalues = sm.GetList();
            return View(skillvalues);
        }
        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            var skillvalues = sm.GetById(id);
            return View(skillvalues);
        }
        [HttpPost]
        public ActionResult EditSkill(Skill skill)
        {
            sm.AboutUpdateBL(skill);
            return RedirectToAction("Index");
        }
    }
}