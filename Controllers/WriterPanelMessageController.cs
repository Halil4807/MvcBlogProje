using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProje.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidar = new MessageValidator();
        public ActionResult Index()
        {
            var messagelist = mm.GetListInbox();
            return View(messagelist);
        }
        public PartialViewResult WriterMailMenuPartial()
        {
            var messagelistSend = mm.GetListSendboxNotRead();
            ViewBag.SendMailCount = messagelistSend.Count();
            var messagelistInbox = mm.GetListInboxNotRead();
            ViewBag.InboxMailCount = messagelistInbox.Count();
            return PartialView();
        }
        public ActionResult Sendbox()
        {
            var messagelist = mm.GetListSendbox();
            return View(messagelist);
        }
    }
}