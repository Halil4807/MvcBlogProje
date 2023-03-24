using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetListBL();
        Writer GetByIDBL(int id);
        int GetWriterIdBL(string writermail);
        void WriterAddBL(Writer writer);
        void WriterUpdateBL(Writer writer);
        void WriterDeleteBL(Writer writer);
        bool WriterLogin(Writer writer);
    }
}
