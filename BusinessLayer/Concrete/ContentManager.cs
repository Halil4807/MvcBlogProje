using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAddBL(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentDeleteBL(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdateBL(Content content)
        {
            throw new NotImplementedException();
        }

        public Content GetByIDBL(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetListBL()
        {
            throw new NotImplementedException();
        }

        public List<Content> GetListByIDBL(int id)
        {
            return _contentDal.List(x => x.HeadingID == id);
        }

        public List<Content> GetListWriterIDBL(int id)
        {
            return _contentDal.List(x => x.WriterID == id);
        }
    }
}
