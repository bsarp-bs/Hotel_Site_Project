using System;
using System.Collections.Generic;
using System.Text;

namespace API.DataAccessLayer.Abstract
{
    public interface IGenericDAL<T> where T : class
    {
        void Insert(T t);

        void Delete(T t);

        void Update(T t);

        List<T> GetListAll();

        T GetByID(int id);

       }
}
