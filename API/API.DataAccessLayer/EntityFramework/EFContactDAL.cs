using API.DataAccessLayer.Abstract;
using API.DataAccessLayer.Generic;
using API.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace API.DataAccessLayer.EntityFramework
{
    public class EFContactDAL : GenericRepositoryDAL<Contact>, IContactDAL
    {
    }
}
