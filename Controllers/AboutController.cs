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
    public class AboutController : Controller
    {
        // GET: About
        AboutManager abm = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutvalue = abm.GetList();
            return View(aboutvalue);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            abm.AboutAddBL(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AddAboutPartial()
        {
            return PartialView();
        }
        public ActionResult DeleteAbout(int id)
        {
            var AboutValue = abm.GetById(id);
            if (AboutValue.AboutStatus == true)
            {
                AboutValue.AboutStatus = false;
            }
            else
            {
                AboutValue.AboutStatus = true;
            }
            abm.AboutUpdateBL(AboutValue);
            return RedirectToAction("Index");
        }
    }
}