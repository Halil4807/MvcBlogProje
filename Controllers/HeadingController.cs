using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProje.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var headingvalue = hm.GetList();
            return View(headingvalue);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> categorylist = (from x in cm.GetList() select new SelectListItem {Text=x.CategoryName, Value=x.CategoryID.ToString() }).ToList();
            ViewBag.categoriler = categorylist;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Now;
            //heading.HeadingDate =DateTime.Parse(DateTime.Now.ToLongTimeString());  Sadece tarihi alma
            hm.HeadingAddBL(heading);
            return RedirectToAction("Index");
        }
    }
}