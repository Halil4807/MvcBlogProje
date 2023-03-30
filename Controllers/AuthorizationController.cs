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
    [Authorize(Roles = "A")]
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager adm = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var adminvalues = adm.GetList();
            return View(adminvalues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            admin.AdminPassword = adm.hashADM(admin.AdminPassword);
            adm.AdminAddBL(admin);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(Roles = "A")]
        public ActionResult EditAdmin(int id)
        {
            var categoryValue = adm.GetById(id);
            return View(categoryValue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            adm.AdminUpdateBL(admin);
            return RedirectToAction("Index");
        }
    }
}