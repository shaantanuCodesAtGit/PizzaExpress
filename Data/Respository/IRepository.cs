using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Respository
{
    public interface IRepository<T> where T : class
    {
        T Find(Func<T, bool> predicate);

        List<T> Get(Func<T, bool> predicate);

        List<T> GetAll();

        T Create(T data);

        T Update(T data);
    }
}
