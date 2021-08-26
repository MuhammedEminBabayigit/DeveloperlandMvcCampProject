using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetList();
        List<Comment> GetListByHeadingID(int id);
        List<Comment> GetListByWriterID(string username);
        void AddComment(Comment p);
        void DeleteComment(Comment p);
        Comment GetByID(int id);
        void UpdateComment(Comment p);
    }
}
