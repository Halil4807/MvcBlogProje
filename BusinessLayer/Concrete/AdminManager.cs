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
