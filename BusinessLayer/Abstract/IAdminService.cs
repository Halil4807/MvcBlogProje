using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetList();
        void AdminAddBL(Admin about);
        Admin GetById(int id);
        bool AdminLogin(Admin admin);
        void AdminDeleteBL(Admin about);
        void AdminUpdateBL(Admin about);
    }
}
