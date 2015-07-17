
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EntityFrameworkBites.Services.Repositories
{
    public interface IGenericRepository<T>
    {
        void InsertOrUpdate(T entity);
        IQueryable<T> All();
        T Single(Expression<Func<T, bool>> predicate);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        void Delete(T entity);
        void Edit(T entity);
    }
}
