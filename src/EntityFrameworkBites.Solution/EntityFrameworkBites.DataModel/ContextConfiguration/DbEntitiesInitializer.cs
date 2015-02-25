using System.Data.Entity;

namespace EntityFrameworkBites.DataModel.ContextConfiguration
{
    public class DbEntitiesInitializer : CreateDatabaseIfNotExists<DbEntities>
    {
        protected override void Seed(DbEntities context)
        {
            base.Seed(context);
        }
    }

    
}
