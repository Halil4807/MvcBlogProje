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
        WriterManager wm = new WriterManager(new EfWriterDal());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            //Context c = new Context();
            //var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
            //if (adminuserinfo != null)
            //{
            //    FormsAuthentication.SetAuthCookie(admin.AdminUserName, false);
            //    Session["AdminUserName"] = admin.AdminUserName;
            //    return RedirectToAction("Index", "AdminCategory");
            //}
            //else
            //{
            //    return RedirectToAction("Index");
            //}

            
            if (adm.AdminLogin(admin))
            {
                string username=adm.hashADM(admin.AdminUserName);
                FormsAuthentication.SetAuthCookie(username, false);
                Session["AdminUserName"] = username;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            if (wm.WriterLogin(writer))
            {
                //string username = adm.hashADM(writer.WriterMail);
                //FormsAuthentication.SetAuthCookie(username, false);
                //Session["AdminUserName"] = username;
                return RedirectToAction("WriterProfile", "WriterPanel");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }
    }
}