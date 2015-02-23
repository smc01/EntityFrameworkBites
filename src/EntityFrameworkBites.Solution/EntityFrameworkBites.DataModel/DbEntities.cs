using EntityFrameworkBites.DataModel.Base;
using System.Data.Entity;
using EntityFrameworkBites.DataModel.ContextConfiguration;

namespace EntityFrameworkBites.DataModel
{
    public class DbEntities : DbContext, IDbEntities
    {
        public DbEntities()
            : base("DbConnectionString")
        {
            //Database.SetInitializer(new DbEntitiesInitializer());

            
        }
        public IDbSet<Entities.Product> ProductSet { get; set; }
    }
}
