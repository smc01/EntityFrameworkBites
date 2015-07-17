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
        public virtual DbSet<Product> ProductSet { get; set; }
        public virtual DbSet<ProductCategory> ProductCategorieSet { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Product>().HasKey(s=>s.Id).Property(p=>p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ProductCategory>().HasKey(s => s.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
