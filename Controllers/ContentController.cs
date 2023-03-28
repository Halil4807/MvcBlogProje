using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
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

        //Mimariyr uygun
        [AllowAnonymous]
        public ActionResult GetAllContent(string parametre)
        {
            var values = cm.GetListBL(parametre);
            if (string.IsNullOrEmpty(parametre))
            {
                values = cm.GetListBL();
            }
            return View(values);
        }

        //Mimariye uygun olmadan
        //Context c = new Context();
        //[AllowAnonymous]
        //public ActionResult GetAllContent(string parametre)
        //{
        //    //var values = c.Contents.ToList(); //Tüm verileri getirme
        //    var values = from x in c.Contents select x;
        //    if(!string.IsNullOrEmpty(parametre))
        //    {
        //        values = values.Where(y => y.ContentValue.Contains(parametre));
        //    }
        //    return View(values.ToList());
        //}



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