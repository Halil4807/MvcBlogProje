using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcBlogProje.Controllers
{
    public class AdminController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDal());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            if (adm.AdminLogin(admin))
            {
                FormsAuthentication.SetAuthCookie(admin.AdminUserName, false);
                Session["AdminMail"] = admin.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}