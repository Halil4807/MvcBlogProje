using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        Context c = new Context();
        DbSet<Category> _object;
        public void Delete(Category parametre)
        {
            _object.Remove(parametre);
            c.SaveChanges();
            //throw new NotImplementedException();
        }

        public void Insert(Category parametre)
        {
            _object.Add(parametre);
            c.SaveChanges();
            //throw new NotImplementedException();
        }

        public List<Category> List()
        {
            return _object.ToList();
            //throw new NotImplementedException();
        }

        public void Update(Category parametre)
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