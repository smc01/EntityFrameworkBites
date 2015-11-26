using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EntityFrameworkBites.Services.Repositories
{
    public interface IRepository<T> 
    {
        void Add(T item);
        void Edit(T item);
        void Delete(T item);

        IEnumerable<T> All();
        T Find(int id);

        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
    }
}
