using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using EntityFrameworkBites.DataModel.Base;
using System.Data.Entity;
using EntityFrameworkBites.DataModel.ContextConfiguration;
using EntityFrameworkBites.Entities;

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
        public virtual DbSet<ProductCategory> ProductCategorieSet { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
