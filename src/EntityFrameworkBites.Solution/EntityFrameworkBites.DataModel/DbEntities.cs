using EntityFrameworkBites.DataModel.Base;
using System.Data.Entity;

namespace EntityFrameworkBites.DataModel
{
    public class DbEntities: DbContext, IDbEntities
    {
        public IDbSet<Entities.Product> ProductSet { get; set; }
    }
}
