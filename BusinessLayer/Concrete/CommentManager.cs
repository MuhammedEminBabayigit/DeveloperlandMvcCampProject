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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void AddComment(Comment p)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(Comment p)
        {
            throw new NotImplementedException();
        }

        public Comment GetByID(int id)
        {
            return _commentDal.Get(x => x.CommentID == id);
        }

        public List<Comment> GetList()
        {
            return _commentDal.List();
        }
        public List<Comment> GetListByHeadingID(int id)
        {
            return _commentDal.List(x => x.PostID == id && x.CommentStatus == true);
        }

        public List<Comment> GetListByWriterID(string username)
        {
            return _commentDal.List(x => x.UserName == username);
        }

        public void UpdateComment(Comment p)
        {
            throw new NotImplementedException();
        }
    }
}
