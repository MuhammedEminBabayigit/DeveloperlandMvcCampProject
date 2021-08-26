using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserCommentManager : IUserCommentService
    {
        IUserCommentDal _userCommentDal;

        public UserCommentManager(IUserCommentDal userCommentDal)
        {
            _userCommentDal = userCommentDal;
        }

        public void AddComment(UserComment p)
        {
            _userCommentDal.Insert(p);
        }

        public void DeleteComment(UserComment p)
        {
            _userCommentDal.Update(p);
        }

        public UserComment GetByID(int id)
        {
            return _userCommentDal.Get(x => x.CommentID == id);
        }

        public List<UserComment> GetList()
        {
            return _userCommentDal.List();
        }

        public List<UserComment> GetListByPostID(int id)
        {
            return _userCommentDal.List(x => x.PostID == id && x.CommentStatus == true);
        }

        public List<UserComment> GetListByWriterID(int id)
        {
            return _userCommentDal.List(x => x.WriterID == id && x.CommentStatus == true);
        }
        public List<UserComment> GetListByWriterIDByFalse(int id)
        {
            return _userCommentDal.List(x => x.WriterID == id && x.CommentStatus == false);
        }
        public void UpdateComment(UserComment p)
        {
            _userCommentDal.Update(p);
        }
    }
}
