using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> repository = new GenericRepository<Category>();

        public List<Category> GetAllBL()
        {
            return repository.List();
        }
        public void CategoryAddBL(Category par)
        {
            if (par.CategoryName == "" || par.CategoryDescription == "" || par.CategoryName.Length <= 3 || par.CategoryName.Length > 50)
            {
                //Hata Mesajı buaraya yazılacak!!
            }
            else
            {
                repository.Insert(par);
            }
        }
    }
}
