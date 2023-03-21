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
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        //Okunmamış Mesaj sayısını için
        MessageManager mm = new MessageManager(new EfMessageDal());
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var ContactDetail = cm.GetById(id);
            return View(ContactDetail);
        }
        public PartialViewResult MailMenuPartial()
        {
            var messagelist = mm.GetListSendbox();
            ViewBag.SendMailCount = messagelist.Count();
            var messagelistInbox = mm.GetListInbox();
            ViewBag.InboxMailCount = messagelistInbox.Count();
            var contactvalues = cm.GetList();
            ViewBag.ContactMailCount = contactvalues.Count();
            return PartialView();
        }
    }
}