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
        void AddSkill(Skill p);
        void DeleteSkill(Skill p);
        void UpdateSkill(Skill p);
        Skill GetByID(int id);
    }
}
