using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISkillService
    {
        List<Skill> GetList();
        void AboutAddBL(Skill skill);
        Skill GetById(int id);
        void AboutDeleteBL(Skill skill);
        void AboutUpdateBL(Skill skill);
    }
}
