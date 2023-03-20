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
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            //List<SelectListItem> categorylist = (from x in cm.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            //ViewBag.categoriler = categorylist;
            var categorylist= cm.GetList();
            ViewBag.categoriler =  categorylist.Count();
            foreach (var item in categorylist)
            {

            }
            return View();
        }
    }
}