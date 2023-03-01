using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<Tablo>
    {
        List<Tablo> List();

        void Insert(Tablo parametre);
        Tablo Get(Expression<Func<Tablo, bool>> filter);
        void Delete(Tablo parametre);
        void Update(Tablo parametre);
        List<Tablo> List(Expression<Func<Tablo, bool>> filter);
    }
}
