using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProje.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentvalue = cm.GetListByIDBL(id);
            return View(contentvalue);
        }
        public ActionResult ContentByWriter(int id)
        {
            var contentvalue = cm.GetListWriterIDBL(id);
            return View(contentvalue);
        }
    }
}