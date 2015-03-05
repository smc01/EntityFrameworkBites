using System;
using System.Data.Entity;
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
            if (entity.Id == default(int)) // New entity
            {
                _dbEntities.Entry(entity).State = EntityState.Added;
            }
            else        // Existing entity
            {
                _dbSet.Add(entity);
                _dbEntities.Entry(entity).State = EntityState.Modified;
            }
        }


        public System.Linq.IQueryable<T> All()
        {
            throw new NotImplementedException();
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
