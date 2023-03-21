using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();
        List<Contact> GetListNotRead();
        void ContactAddBL(Contact contact);
        Contact GetById(int id);
        void ContactDeleteBL(Contact contact);
        void ContactUpdateBL(Contact contact);
    }
}
