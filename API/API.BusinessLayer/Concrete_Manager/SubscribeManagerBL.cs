using API.BusinessLayer.Service;
using API.DataAccessLayer.Abstract;
using API.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.BusinessLayer.Concrete_Manager
{
    public class SubscribeManagerBL : ISubscribeService
    {
        private readonly ISubscribeDAL subs;

        public SubscribeManagerBL(ISubscribeDAL _subs)
        {
            this.subs = _subs;
        }

        public List<Subscribe> GetAllS()
        {
            return subs.GetListAll();
        }

        public Subscribe Getbyid(int id)
        {
            return subs.GetByID(id);
        }

        public void SDelete(Subscribe s)
        {
            subs.Delete(s);
        }

        public void SInsert(Subscribe s)
        {
            subs.Insert(s);
        }

        public void SUpdate(Subscribe s)
        {
            subs.Update(s);
        }
    }
}
