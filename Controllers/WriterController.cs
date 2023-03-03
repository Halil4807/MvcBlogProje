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
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator writervalidar = new WriterValidator();
        public ActionResult Index()
        {
            var WriterValue = wm.GetListBL();
            return View(WriterValue);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            ValidationResult sonuc = writervalidar.Validate(writer);
            if (sonuc.IsValid)
            {
                wm.WriterAddBL(writer);
                return RedirectToAction("Index");
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
         [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writervalue = wm.GetByIDBL(id);
            return View(writervalue);
        }
        [HttpPost]
        public ActionResult EditWriter(Writer yazar)
        {
            ValidationResult sonuc = writervalidar.Validate(yazar);
            if (sonuc.IsValid)
            {
                wm.WriterUpdateBL(yazar);
                return RedirectToAction("Index");
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