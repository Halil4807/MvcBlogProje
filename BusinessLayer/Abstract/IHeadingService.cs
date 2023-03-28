using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetList(int id);
        List<Heading> GetWriterList(int id);
        List<Heading> GetListByWriter(int id);
        void HeadingAddBL(Heading heading);
        Heading GetById(int id);
        void HeadingDeleteBL(Heading heading);
        void HeadingUpdateBL(Heading heading);
    }
}
