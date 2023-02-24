using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<Tablo> : IRepository<Tablo> where Tablo : class
    {
        Context c = new Context();
        DbSet<Tablo> _object;

        public GenericRepository()
        {
            _object = c.Set<Tablo>();
        }

        public void Delete(Tablo parametre)
        {
            _object.Remove(parametre);
            c.SaveChanges();
            //throw new NotImplementedException();
        }

        public void Insert(Tablo parametre)
        {
            _object.Add(parametre);
            c.SaveChanges();
            //throw new NotImplementedException();
        }

        public List<Tablo> List()
        {
            return _object.ToList();
            //throw new NotImplementedException();
        }

        public List<Tablo> List(Expression<Func<Tablo, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Tablo parametre)
        {
            //Değişikler direk olarak kaydedilir. Çünkü güncellemeden önce değişiklikler zaten yansıtılıyor.
            c.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}

/*
Entity Framework'te kullanılan methodlar
Tolist Listeleme
Add ekleme
Remove Silme
Find Bulma
*/