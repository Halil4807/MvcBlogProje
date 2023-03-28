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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox(string mail)
        {
            return _messageDal.List(x => x.ReceiverMail == mail);
        }

        public List<Message> GetListInbox(string mail, string search)
        {
            return _messageDal.List(x => x.ReceiverMail == mail && x.MessageContent.Contains(search));
        }

        public List<Message> GetListInboxNotRead(string mail)
        {
            return _messageDal.List(x => x.ReceiverMail == mail && x.MessageRead == false);
        }

        public List<Message> GetListSendbox(string mail)
        {
            return _messageDal.List(x => x.SenderMail == mail);
        }

        public List<Message> GetListSendbox(string mail, string search)
        {
            return _messageDal.List(x => x.SenderMail == mail && x.MessageContent.Contains(search));
        }

        public List<Message> GetListSendboxNotRead(string mail)
        {
            return _messageDal.List(x => x.SenderMail == mail && x.MessageRead == false);
        }

        public void MessageAddBL(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDeleteBL(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdateBL(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
