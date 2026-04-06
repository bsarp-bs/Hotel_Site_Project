using API.BusinessLayer.Service;
using API.DataAccessLayer.Abstract;
using API.EntityLayer.Concrete;

namespace API.BusinessLayer.Concrete_Manager
{
    public class ContactManagerBL : IContactService
    {
        private readonly IContactDAL _contactDAL;

        public ContactManagerBL(IContactDAL contactDAL)
        {
            _contactDAL = contactDAL;
        }

        public List<Contact> GetAllS()
        {
            return _contactDAL.GetListAll();
        }

        public Contact Getbyid(int id)
        {
            return _contactDAL.GetByID(id);
        }

        public void SDelete(Contact s)
        {
            _contactDAL.Delete(s);
        }

        public void SInsert(Contact s)
        {
            _contactDAL.Insert(s);
        }

        public void SUpdate(Contact s)
        {
            _contactDAL.Update(s);
        }
    }
}
