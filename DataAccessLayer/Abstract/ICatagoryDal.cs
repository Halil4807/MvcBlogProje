using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICatagoryDal
    {
        //CRUD Operasyonları
        //Type Name()
        List<Category> List();

        void Insert(Category parametre);

        void Update(Category parametre);

        void Delete(Category parametre);

    }
}
