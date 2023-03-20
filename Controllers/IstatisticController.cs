using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProje.Controllers
{
    public class IstatisticController : Controller
    {
        // GET: Istatistic
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            //List<SelectListItem> categorylist = (from x in cm.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            //ViewBag.categoriler = categorylist;
            var categoryalllist= cm.GetList();
            ViewBag.categoriler = categoryalllist.Count();
            var categoryYazılımlist = hm.GetList(7);
            ViewBag.yazılımcount = categoryYazılımlist.Count();
            return View();
        }
    }
}