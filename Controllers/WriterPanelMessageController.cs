using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        public ActionResult Index(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                ViewBag.search="";
                var messagelist = mm.GetListInbox((string)Session["WriterMail"]);
                return View(messagelist);
            }
            else
            {
                ViewBag.search = search;
                var messagelist = mm.GetListInbox((string)Session["WriterMail"], search);
                return View(messagelist);
            }
        }
        public PartialViewResult WriterMailMenuPartial()
        {
            var messagelistSend = mm.GetListSendboxNotRead((string)Session["WriterMail"]);
            ViewBag.SendMailCount = messagelistSend.Count();
            var messagelistInbox = mm.GetListInboxNotRead((string)Session["WriterMail"]);
            ViewBag.InboxMailCount = messagelistInbox.Count();
            return PartialView();
        }
        public ActionResult Sendbox(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                ViewBag.search = "";
                var messagelist = mm.GetListSendbox((string)Session["WriterMail"]);
                return View(messagelist);
            }
            else
            {
                ViewBag.search = search;
                var messagelist = mm.GetListSendbox((string)Session["WriterMail"],search);
                return View(messagelist);
            }

        }
        public ActionResult GetMessageDetails(int id)
        {
            var value = mm.GetById(id);
            value.MessageRead = true;
            mm.MessageUpdateBL(value);
            return View(value);
        }

        public ActionResult GetSendMessageDetails(int id)
        {
            var value = mm.GetById(id);
            value.MessageRead = true;
            mm.MessageUpdateBL(value);
            return View(value);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult sonuc = messagevalidar.Validate(message);
            message.MessageDate = DateTime.Now; //Şuanki tarihi MessageDate'e aktarma
            if (sonuc.IsValid)
            {
                mm.MessageAddBL(message);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in sonuc.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}