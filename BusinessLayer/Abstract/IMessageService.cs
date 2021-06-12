using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox();
        List<Message> GetListSendbox();
        List<Message> GetListDrafts();

        void AddMessage(Message message);
        void MessageDelete(Message message);

        void MessageUpdate(Message message);

        Message GetByID(int id);
    }
}
