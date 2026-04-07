using API.BusinessLayer.Service;
using API.DataAccessLayer.Abstract;
using API.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.BusinessLayer.Concrete_Manager
{
    public class ContactCategoryManagerBL : IContactCategoryService
    {
        private readonly IContactCategoryDAL _contactCategory;

        public ContactCategoryManagerBL(IContactCategoryDAL contactCategory)
        {
            _contactCategory = contactCategory;
        }

        public List<ContactCategory> GetAllS()
        {
            var value = _contactCategory.GetListAll();
            return value;
        }

        public ContactCategory Getbyid(int id)
        {
            return _contactCategory.GetByID(id);
        }

        public void SDelete(ContactCategory s)
        {
            _contactCategory.Delete(s);
        }

        public void SInsert(ContactCategory s)
        {
            _contactCategory.Insert(s);
        }

        public void SUpdate(ContactCategory s)
        {
            _contactCategory.Update(s);
        }
    }
}
