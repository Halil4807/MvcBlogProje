using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetListBL();
        List<Content> GetListBL(string parametre);
        List<Content> GetListByIDBL(int id);
        List<Content> GetListWriterIDBL(int id);
        Content GetByIDBL(int id);
        void ContentAddBL(Content content);
        void ContentUpdateBL(Content content);
        void ContentDeleteBL(Content content);
    }
}
