using API.BusinessLayer.Service;
using API.DataAccessLayer.Abstract;
using API.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.BusinessLayer.Concrete_Manager
{
    public class BookingManagerBL : IBookingService
    {
        private readonly IBookingDAL _bookingdal;

        public BookingManagerBL(IBookingDAL bookingdal)
        {
            _bookingdal = bookingdal;
        }

        public List<Booking> GetAllS()
        {
            return _bookingdal.GetListAll();
        }

        public Booking Getbyid(int id)
        {
            return _bookingdal.GetByID(id);
        }

        public void SDelete(Booking s)
        {
            _bookingdal.Delete(s);
        }

        public void SInsert(Booking s)
        {
            _bookingdal.Insert(s);
        }

        public void SUpdate(Booking s)
        {
            _bookingdal.Update(s);
        }
    }
}
