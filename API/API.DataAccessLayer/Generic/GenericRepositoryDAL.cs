using API.DataAccessLayer.Abstract;
using API.DataAccessLayer.Concrete_Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.DataAccessLayer.Generic
{
    public class GenericRepositoryDAL<T> : IGenericDAL<T> where T : class
    {
        
        public void Delete(T t)
        {
            using Context C = new Context();
                C.Remove(t);
                C.SaveChanges();
        }

        public T GetByID(int id)
        {
            using Context C = new Context();
            var value = C.Set<T>().Find(id);
            return value;
        }

        public List<T> GetListAll()
        {
            using Context C = new Context();
            return C.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            using Context C = new Context();
            C.Add(t);
            C.SaveChanges();
        }

        public void Update(T t)
        {
            using Context C = new Context();
            C.Update(t);
            C.SaveChanges();
        }
    }

}
