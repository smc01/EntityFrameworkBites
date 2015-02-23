using EntityFrameworkBites.Entities;
using System.Data.Entity;

namespace EntityFrameworkBites.DataModel.Base
{
    public interface IDbEntities
    {
        IDbSet<Product> ProductSet { get; set; }

        int SaveChanges();
    }
}
