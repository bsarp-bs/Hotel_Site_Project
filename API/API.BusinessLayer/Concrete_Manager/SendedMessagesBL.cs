using API.BusinessLayer.Service;
using API.DataAccessLayer.Abstract;
using API.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.BusinessLayer.Concrete_Manager
{
    public class SendedMessagesBL : ISendedMessagesService
    {
        private readonly ISendedMessagesDAL _sended;

        public SendedMessagesBL(ISendedMessagesDAL sended)
        {
            _sended = sended;
        }

        public List<SendedMessages> GetAllS()
        {
            return _sended.GetListAll();
        }

        public SendedMessages Getbyid(int id)
        {
            return _sended.GetByID(id);
        }

        public void SDelete(SendedMessages s)
        {
            _sended.Delete(s);
        }

        public void SInsert(SendedMessages s)
        {
            _sended.Insert(s);
        }

        public void SUpdate(SendedMessages s)
        {
            _sended.Update(s);
        }
    }
}
