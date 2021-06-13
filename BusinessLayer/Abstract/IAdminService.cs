using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService 
    {
        List<Admin> GetList();

        void AddAdmin(Admin Admin);
        void AdminDelete(Admin Admin);

        void AdminUpdate(Admin Admin);

        Admin GetByID(int id);
        Admin GetByNicknameAndPassword(Admin Admin);
    }
}
