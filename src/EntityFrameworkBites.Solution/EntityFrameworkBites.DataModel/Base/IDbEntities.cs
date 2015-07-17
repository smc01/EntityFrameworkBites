using EntityFrameworkBites.Entities;
using System.Data.Entity;

namespace EntityFrameworkBites.DataModel.Base
{
    public interface IDbEntities
    {
        DbSet<Product> ProductSet { get; set; }
        DbSet<ProductCategory> ProductCategorieSet { get; set; } 
        int SaveChanges();
    }
}
