using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using EntityFrameworkBites.DataModel;
using EntityFrameworkBites.Entities.Base;

namespace EntityFrameworkBites.Services.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : IntEntityBase
 
    {
        private readonly DbEntities _dbEntities;
        private readonly DbSet<T> _dbSet; 
        public GenericRepository(DbEntities dbContext)
        {
            _dbEntities = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public void InsertOrUpdate(T entity)
        {
            DbEntityEntry dbEntityEntry = _dbEntities.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                _dbSet.Add(entity);
            }
        }


        public System.Linq.IQueryable<T> All()
        {
            return _dbSet.Where(p=>1==1);
        }

        public T Single(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbSet.SingleOrDefault(predicate);
        }

        public IQueryable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}
