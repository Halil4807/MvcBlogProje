using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminAddBL(Admin about)
        {
            throw new NotImplementedException();
        }

        public void AdminDeleteBL(Admin about)
        {
            throw new NotImplementedException();
        }

        public bool AdminLogin(Admin admin)
        {
            var admininfo= _adminDal.Get(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
            if(admininfo!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AdminUpdateBL(Admin about)
        {
            throw new NotImplementedException();
        }

        public Admin GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
