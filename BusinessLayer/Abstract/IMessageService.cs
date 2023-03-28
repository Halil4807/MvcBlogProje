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
        List<Message> GetListInbox(string mail);
        List<Message> GetListInbox(string mail,string search);
        List<Message> GetListInboxNotRead(string mail);
        List<Message> GetListSendbox(string mail);
        List<Message> GetListSendbox(string mail, string search);
        List<Message> GetListSendboxNotRead(string mail);
        void MessageAddBL(Message message);
        Message GetById(int id);
        void MessageDeleteBL(Message message);
        void MessageUpdateBL(Message message);
    }
}
