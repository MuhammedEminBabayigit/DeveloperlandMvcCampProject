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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetByID(int id)
        {
            return _writerDal.Get(x => x.WriterID == id);
        }

        public Writer GetByNickName(string p)
        {
            return _writerDal.Get(x => x.WriterNickName == p);
        }

        public Writer GetByUsernameAndPassword(Writer writer)
        {
            return _writerDal.Get(x => x.WriterNickName == writer.WriterNickName && x.WriterPassword == writer.WriterPassword);
        }

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public void WriterAdd(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
