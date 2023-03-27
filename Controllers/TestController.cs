using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProje.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        AdminManager adm = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            string resultusername = adm.hashADM("1");
            ViewBag.username = resultusername;
            return View();
        }
        [AllowAnonymous]
        public ActionResult HomePage()
        {
            return View();
        }
    }
}