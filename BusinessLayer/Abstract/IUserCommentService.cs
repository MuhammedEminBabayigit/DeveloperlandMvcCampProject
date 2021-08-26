using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserCommentService
    {
        List<UserComment> GetList();
        List<UserComment> GetListByPostID(int id);
        List<UserComment> GetListByWriterID(int id);
        List<UserComment> GetListByWriterIDByFalse(int id);
        void AddComment(UserComment p);
        void DeleteComment(UserComment p);
        UserComment GetByID(int id);
        void UpdateComment(UserComment p);
    }
}
