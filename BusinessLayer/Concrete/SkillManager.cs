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
        ISkillDal _skilldal;

        public SkillManager(ISkillDal skilldal)
        {
            _skilldal = skilldal;
        }

        public Skill GetByID(int id)
        {
            return _skilldal.Get(x=>x.SkillId== id);
        }

        public List<Skill> GetList()
        {
            return _skilldal.List();
        }

        public void SkillAdd(Skill skill)
        {
            _skilldal.Insert(skill);
        }

        public void SkillDelete(Skill skill)
        {
            _skilldal.Delete(skill);
        }

        public void SkillUpdate(Skill skill)
        {
            _skilldal.Update(skill);
        }
    }
}
