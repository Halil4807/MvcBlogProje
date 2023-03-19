using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concrete;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MvcBlogProje.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EfMessageDal());
        public ActionResult Inbox()
        {
            var messagelist = mm.GetListInbox();
            return View(messagelist);
        }
        public ActionResult Sendbox()
        {
            var messagelist = mm.GetListSendbox();
            return View(messagelist);
        }

        public ActionResult GetMessageDetails(int id)
        {
            var value = mm.GetById(id);
            return View(value);
        }

        public ActionResult GetSendMessageDetails(int id)
        {
            var value = mm.GetById(id);
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
            MessageValidator messagevalidar = new MessageValidator();
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