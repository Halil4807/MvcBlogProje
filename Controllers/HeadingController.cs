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
        WriterManager wm = new WriterManager(new EfWriterDal());
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
            List<SelectListItem> yazarlarlist = (from x in wm.GetListBL() select new SelectListItem { Text = x.WriterName + " " + x.WriterSurName, Value = x.WriterID.ToString() }).ToList();
            ViewBag.yazarlar = yazarlarlist;
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
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = hm.GetById(id);
            if (HeadingValue.HeadingStatus == true)
            {
                HeadingValue.HeadingStatus = false;
            }
            else
            {
                HeadingValue.HeadingStatus = true;
            }
            hm.HeadingDeleteBL(HeadingValue);
            return RedirectToAction("Index");
        }
    }
}