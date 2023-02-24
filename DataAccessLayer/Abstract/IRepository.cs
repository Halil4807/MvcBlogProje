using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<Tablo>
    {
        List<Tablo> List();

        void Insert(Tablo parametre);
        void Delete(Tablo parametre);
        void Update(Tablo parametre);
    }
}
