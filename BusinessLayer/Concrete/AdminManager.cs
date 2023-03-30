using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public void AdminAddBL(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public void AdminDeleteBL(Admin admin)
        {
            throw new NotImplementedException();
        }

        public bool AdminLogin(Admin admin)
        {
            //string resultusername = hashADM(admin.AdminUserName);
            string resultusername = admin.AdminUserName;
            string resultpassword = hashADM(admin.AdminPassword);
            var admininfo= _adminDal.Get(x => x.AdminUserName == resultusername && x.AdminPassword == resultpassword);
            if(admininfo!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AdminUpdateBL(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public Admin GetById(int id)
        {
            return _adminDal.Get(x => x.AdminID == id);
        }

        public List<Admin> GetList()
        {
            return _adminDal.List();
        }
        public string hashADM(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
