using API.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.BusinessLayer.Service
{
    public interface IGenericService<S> where S : class
    {

        void SInsert(S s);

        void SDelete(S s);

        void SUpdate(S s);

        List<S> GetAllS();

        S Getbyid(int id);

    }
}
