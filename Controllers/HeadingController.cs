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
        public ActionResult Index()
        {
            var headingvalue = hm.GetList();
            return View(headingvalue);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
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