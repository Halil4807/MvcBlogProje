using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProje.Controllers
{
    public class IstatisticController : Controller
    {
        // GET: Istatistic
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            //Toplam Kategori Sayısı
            var categoryalllist = cm.GetList();
            ViewBag.categoriler = categoryalllist.Count();
            //Yazılım'a ait Yazıların Sayısı Yazılımın kategori id=7
            var heasingYazılımlist = hm.GetList(7);
            ViewBag.yazılımcount = heasingYazılımlist.Count();
            //Adında "a" geçen yazarların Sayısı
            var yazarlist = wm.GetListBL();
            int yazar_a_say = 0;
            foreach (var item in yazarlist)
            {
                if (item.WriterName.ToLower().IndexOf("a") >= 0)
                {
                    yazar_a_say++;
                }
            }

            //Ençok yazıya sahip kategoriyi bulma
            int categorybasliksayisi = 0, categoryanlik = 0;
            string categoryad = "";
            var headingcategorilist=hm.GetList();
            foreach (var item in categoryalllist)
            {
                categoryanlik = 0;
                headingcategorilist = hm.GetList(item.CategoryID);
                categoryanlik = headingcategorilist.Count();
                if (categoryanlik >= categorybasliksayisi)
                {
                    categoryad = item.CategoryName;
                    categorybasliksayisi = categoryanlik;
                }
            }
            ViewBag.encokcategory = categoryad;
            ViewBag.encokcategorysayisi = categorybasliksayisi;

            //Kagerisi "True" ve "False" olanların sayısı
            int categorytrue = 0, categoryfalse = 0, categorydifference = 0;
            foreach (var item in categoryalllist)
            {
                if (item.CaterogyStatus)
                {
                    categorytrue++;
                }
                else
                {
                    categoryfalse++;
                }
            }
            categorydifference = categorytrue - categoryfalse;
            ViewBag.categorytrue = categorytrue;
            ViewBag.categoryfalse = categoryfalse;
            ViewBag.categorydifference = categorydifference;
            ViewBag.yazarsay = yazar_a_say;
            return View();
        }
    }
}