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
    public class SkillManager : ISkillService
    {
        ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public void AboutAddBL(Skill skill)
        {
            _skillDal.Insert(skill);
        }

        public void AboutDeleteBL(Skill skill)
        {
            throw new NotImplementedException();
        }

        public void AboutUpdateBL(Skill skill)
        {
            _skillDal.Update(skill);
        }

        public Skill GetById(int id)
        {
            return _skillDal.Get(x => x.SkillID == id);
        }

        public List<Skill> GetList()
        {
            return _skillDal.List();
        }
    }
}
