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
    public class PostManager : IPostService
    {
        IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public void ActivePost(Post p)
        {
            _postDal.Update(p);
        }

        public void AddPost(Post p)
        {
            _postDal.Insert(p);
        }

        public void DeletePost(Post p)
        {
            _postDal.Update(p);        
        }

        public Post GetByID(int id)
        {
            return _postDal.Get(x => x.PostID == id);
        }
        
        public List<Post> GetList()
        {
            return _postDal.List();
        }

        public void UpdatePost(Post p)
        {
            _postDal.Update(p);
        }

    }
}
