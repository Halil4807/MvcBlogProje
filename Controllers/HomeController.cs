using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProje.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Headings()
        {
            var headingList = hm.GetList();
            return View(headingList);
        }
        public PartialViewResult Index(int? id)
        {
            if (id == null)
            {
                ViewBag.HeadingName = "Tüm Yorumlar";
                var contentList = cm.GetListBL();
                return PartialView(contentList);
            }
            else
            {
                int value = (int)id;
                ViewBag.HeadingName = hm.GetById(value).HeadingName;
                var contentList = cm.GetListByIDBL(value);
                return PartialView(contentList);
            }
        }
        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult SweetAlert()
        {
            return View();
        }
    }
}