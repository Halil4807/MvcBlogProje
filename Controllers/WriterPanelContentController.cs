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
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager cm = new ContentManager(new EfContentDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        public ActionResult MyContent()
        {
            string parametre = (string)Session["WriterMail"];
            int id = wm.GetWriterIdBL(parametre);
            var contentvalue = cm.GetListWriterIDBL(id);
            return View(contentvalue);
        }
        [HttpGet]
        public ActionResult NewContent(int id)
        {
            ViewBag.HeadingName = hm.GetById(id).HeadingName;
            ViewBag.HeadingId = id;
            return View();
        }
        [HttpPost]
        public ActionResult NewContent(Content content)
        {
            string parametre = (string)Session["WriterMail"];
            int id = wm.GetWriterIdBL(parametre);
            content.WriterID = id;
            content.ContentDate = DateTime.Now;
            content.ContentStatus = true;
            cm.ContentAddBL(content);
            return RedirectToAction("MyContent");
        }
    }
}