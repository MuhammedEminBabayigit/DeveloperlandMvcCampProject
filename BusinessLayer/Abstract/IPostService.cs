using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPostService
    {
        List<Post> GetList();
        List<Post> GetListByWriter(int id);
        void AddPost(Post p);
        void DeletePost(Post p);
        Post GetByID(int id);
        void UpdatePost(Post p);

        void ActivePost(Post p);

    }
}
