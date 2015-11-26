using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using EntityFrameworkBites.DataModel;
using EntityFrameworkBites.DataModel.Base;
using EntityFrameworkBites.Entities.Base;

namespace EntityFrameworkBites.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbEntities _context;

        public UnitOfWork(DbEntities context)
        {
            this._context = context;
        }

        internal DbSet<T> GetDbSet<T>()
        where T : class
        {
            return _context.Set<T>();
        }

        internal DbEntityEntry<T> GetDbEntityEntry<T>(T item) where T : IntEntityBase
        {
            return _context.Entry(item);
        }

        public IDbEntities Context { get; private set; }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
