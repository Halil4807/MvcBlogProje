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
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult WriterProfile()
        {
            return View();
        }
        public ActionResult MyHeading()
        {
            int id = wm.GetWriterIdBL((string)Session["WriterMail"]);
            var headingvalue = hm.GetListByWriter(id);
            return View(headingvalue);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> categorylist = (from x in cm.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.categoriler = categorylist;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Now;
            heading.WriterID = wm.GetWriterIdBL((string)Session["WriterMail"]);
            heading.HeadingStatus = true;
            hm.HeadingAddBL(heading);
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> categorylist = (from x in cm.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.categoriler = categorylist;
            var headingvalue = hm.GetById(id);
            return View(headingvalue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            hm.HeadingUpdateBL(heading);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = hm.GetById(id);
            HeadingValue.HeadingStatus = false;
            hm.HeadingDeleteBL(HeadingValue);
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading()
        {
            var allHeadingList = hm.GetList();
            return View(allHeadingList);
        }
    }
}