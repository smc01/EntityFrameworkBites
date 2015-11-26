using System.Data.Entity.Infrastructure;
using EntityFrameworkBites.Entities;
using System.Data.Entity;

namespace EntityFrameworkBites.DataModel.Base
{

    public interface IDbEntitiesGeneric
    {
      
        DbSet<T> GetDbSet<T>() where T : class;
        DbEntityEntry<T> DbEntityEntry<T>(T entity) where T : class;
    }

    public interface IDbEntities : IDbEntitiesGeneric
    {
        DbSet<Product> ProductSet { get; set; }
        DbSet<ProductCategory> ProductCategorieSet { get; set; }

        int SaveChanges();
    }
}
