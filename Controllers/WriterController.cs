using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
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

                if (Request.Files.Count > 0)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/images/writer/" + dosyaadi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    writer.WriterImage = "/images/writer/" + dosyaadi + uzanti;
                    writer.WriterPassword = wm.hashADM(writer.WriterPassword);
                    wm.WriterAddBL(writer);
                }
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
                if (Request.Files.Count > 0)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/images/writer/" + dosyaadi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    yazar.WriterImage = "/images/writer/" + dosyaadi + uzanti;
                    wm.WriterUpdateBL(yazar);
                }

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