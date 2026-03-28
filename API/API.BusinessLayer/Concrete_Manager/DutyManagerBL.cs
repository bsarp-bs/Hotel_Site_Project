using API.BusinessLayer.Service;
using API.DataAccessLayer.Abstract;
using API.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.BusinessLayer.Concrete_Manager
{
    public class DutyManagerBL : IDutyService
    {
        private readonly IDutyDAL duty;

        public DutyManagerBL(IDutyDAL _duty)

        {
            this.duty = _duty;
        }

        public List<Duty> GetAllS()
        {
            return duty.GetListAll();
        }

        public Duty Getbyid(int id)
        {
            return duty.GetByID(id);
        }

        public void SDelete(Duty s)
        {
            duty.Delete(s);
        }

        public void SInsert(Duty s)
        {
            duty.Insert(s);
        }

        public void SUpdate(Duty s)
        {
            duty.Update(s);
        }
    }
}
