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
            var deletedEntity = c.Entry(parametre);
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(parametre);
            c.SaveChanges();
        }

        public Tablo Get(Expression<Func<Tablo, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(Tablo parametre)
        {
            var addEntity = c.Entry(parametre);
            addEntity.State = EntityState.Added;
            //_object.Add(parametre);
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
            return _object.Where(filter).ToList();
            //throw new NotImplementedException();
        }

        public void Update(Tablo parametre)
        {
            var updatedEntity = c.Entry(parametre);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
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