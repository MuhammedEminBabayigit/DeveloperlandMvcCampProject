using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;
        
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AddAdmin(Admin Admin)
        {
            _adminDal.Insert(Admin);
        }

        public void AdminDelete(Admin Admin)
        {
            _adminDal.Update(Admin);
        }

        public void AdminUpdate(Admin Admin)
        {
            _adminDal.Update(Admin);
        }

        

        public Admin GetByID(int id)
        {
            return _adminDal.Get(x => x.AdminID == id);
        }

        public Admin GetByNickname(string p)
        {
            return _adminDal.Get(x => x.AdminNickName == p);
        }

        public Admin GetByNicknameAndPassword(Admin Admin)
        {
            return _adminDal.Get(x => x.AdminNickName == Admin.AdminNickName && x.AdminPassword == Admin.AdminPassword);
        }

        public List<Admin> GetList()
        {
            return _adminDal.List();
        }
    }
}
