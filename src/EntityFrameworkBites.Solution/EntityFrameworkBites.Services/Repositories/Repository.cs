using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using EntityFrameworkBites.Entities.Base;

namespace EntityFrameworkBites.Services.Repositories
{
    public class Repository<T>: IRepository<T> 
            where T:   IntEntityBase
    {
        private readonly IUnitOfWork _unitOfWork; 

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void Add(T item)
        {
            _unitOfWork.Context.GetDbSet<T>().Add(item);
        }

        public void Edit(T item)
        {
            var dbEntityEntry = _unitOfWork.Context.DbEntityEntry(item);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                _unitOfWork.Context.GetDbSet<T>().Attach(item);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public void Delete(T item)
        {
            var dbEntityEntry = _unitOfWork.Context.DbEntityEntry(item);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                _unitOfWork.Context.GetDbSet<T>().Attach(item);
                _unitOfWork.Context.GetDbSet<T>().Remove(item);
            }
        }

        public IEnumerable<T> All()
        {
            return _unitOfWork.Context.GetDbSet<T>();
        }

        public T Find(int id)
        {
           return _unitOfWork.Context.GetDbSet<T>().Find(id);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork.Context.GetDbSet<T>().Where(predicate);
        }
    }
}
