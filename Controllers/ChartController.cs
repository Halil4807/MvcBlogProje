using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using MvcBlogProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProje.Controllers
{
    [AllowAnonymous]
    public class ChartController : Controller
    {
        // GET: Chart

        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(),JsonRequestBehavior.AllowGet);
        }
        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Eğitim",
                CategoryCount = 7
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Seyahat",
                CategoryCount = 4
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 1
            });
            return ct;
        }

        public ActionResult Graphic2()
        {
            return View();
        }
        public ActionResult CategoryDynamicChart()
        {
            return Json(CategoryDynamicList(),JsonRequestBehavior.AllowGet);
        }
        public List<CategoryClass> CategoryDynamicList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            var categeties = cm.GetList();
            foreach (var item in categeties)
            {
                ct.Add(new CategoryClass()
                {
                    CategoryName = item.CategoryName,
                    CategoryCount = hm.GetList(item.CategoryID).Count()
                });;
            }
            return ct;
        }
        public ActionResult Graphic3()
        {
            return View();
        }
        public ActionResult WriterChart()
        {
            return Json(WriterList(),JsonRequestBehavior.AllowGet);
        }
        public List<CategoryClass> WriterList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            var categeties = wm.GetListBL();
            foreach (var item in categeties)
            {
                ct.Add(new CategoryClass()
                {
                    CategoryName = item.WriterName+" "+item.WriterSurName,
                    CategoryCount = hm.GetWriterList(item.WriterID).Count()
                });;
            }
            return ct;
        }
    }
}