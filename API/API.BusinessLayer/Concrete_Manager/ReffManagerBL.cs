using API.BusinessLayer.Service;
using API.DataAccessLayer.Abstract;
using API.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.BusinessLayer.Concrete_Manager
{
    public class ReffManagerBL : IReffService
    {
        private readonly IReffDAL reff;

        public ReffManagerBL(IReffDAL _reff)
        {
            this.reff = _reff;
        }

        public List<Reff> GetAllS()
        {
            return reff.GetListAll();
        }

        public Reff Getbyid(int id)
        {
            return reff.GetByID(id);
        }

        public void SDelete(Reff s)
        {
            reff.Delete(s);
        }

        public void SInsert(Reff s)
        {
            reff.Insert(s);
        }

        public void SUpdate(Reff s)
        {
            reff.Update(s);
        }
    }
}
