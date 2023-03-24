using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProje.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult MyContent()
        {
            int id = 4;
            string parametre = (string)Session["WriterMail"];
            ViewBag.mail = parametre;
            var contentvalue = cm.GetListWriterIDBL(id);
            return View(contentvalue);
        }
    }
}