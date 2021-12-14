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
        IMessageDal _messagedal;

        public MessageManager(IMessageDal messagedal)
        {
            _messagedal = messagedal;
        }

        public Message GetByID(int id)
        {
            var messagevalue = _messagedal.Get(x => x.MessageId == id);
            return messagevalue;
        }

        public List<Message> GetList()
        {
            return _messagedal.List();
        }

        public List<Message> GetListInbox(string p)
        {
            return _messagedal.List(x=>x.Receiver == p && x.isTrash==false);
        }
        public List<Message> GetListAdminInbox()
        {
            return _messagedal.List(x => x.Receiver == "admin@gmail.com" && x.isTrash == false);
        }

        public List<Message> GetListSendbox(string p)
        {
            return _messagedal.List(x => x.SenderMail == p && x.isTrash==false);
        }
        public List<Message> GetListAdminSendbox()
        {
            return _messagedal.List(x => x.SenderMail == "admin@gmail.com" && x.isTrash == false);
        }

        public void MessageAdd(Message message)
        {
            _messagedal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messagedal.Delete(message);
        }

        public void MessageTrash(int id)
        {
           var value= _messagedal.Get(x => x.MessageId == id);
           value.isTrash = true;
            _messagedal.Update(value);

        }

        public void MessageUpdate(Message message)
        {
            _messagedal.Update(message);
        }
    }
}
