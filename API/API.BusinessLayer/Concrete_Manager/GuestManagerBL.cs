using API.BusinessLayer.Service;
using API.DataAccessLayer.Abstract;
using API.EntityLayer.Concrete;

namespace API.BusinessLayer.Concrete_Manager
{
    public class GuestManagerBL : IGuestService
    {
        private readonly IGuestDAL _guest;

        public GuestManagerBL(IGuestDAL guest)
        {
            _guest = guest;
        }

        public List<Guest> GetAllS()
        {
            return _guest.GetListAll();
        }

        public Guest Getbyid(int id)
        {
            return _guest.GetByID(id);
        }

        public void SDelete(Guest s)
        {
            _guest.Delete(s);
        }

        public void SInsert(Guest s)
        {
            _guest.Insert(s);
        }

        public void SUpdate(Guest s)
        {
            _guest.Update(s);
        }
    }
}
