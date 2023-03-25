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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetByIDBL(int id)
        {
            return _writerDal.Get(x => x.WriterID == id);
        }

        public List<Writer> GetListBL()
        {
            return _writerDal.List();
        }

        public void WriterAddBL(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void WriterDeleteBL(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void WriterUpdateBL(Writer writer)
        {
            _writerDal.Update(writer);
            //throw new NotImplementedException();
        }
        public bool WriterLogin(Writer writer)
        {
            string resultusername = hashADM(writer.WriterMail);
            string resultpassword = hashADM(writer.WriterPassword);
            var admininfo = _writerDal.Get(x => x.WriterMail == resultusername && x.WriterPassword == resultpassword);
            if (admininfo != null)
            {
                return true;
            }
            else
            {
                return false;
            }
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

        public int GetWriterIdBL(string writermail)
        {
            int result = _writerDal.Get(x => x.WriterMail == writermail).WriterID;
            return result;
        }
    }
}
