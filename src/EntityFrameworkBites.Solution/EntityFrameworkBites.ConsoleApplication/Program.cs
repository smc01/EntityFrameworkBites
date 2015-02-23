using EntityFrameworkBites.DataModel;
using EntityFrameworkBites.Entities;

namespace EntityFrameworkBites.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var dbEntities = new DbEntities())
            {
                dbEntities.ProductSet.Add(new Product() {Id = 1});
                dbEntities.SaveChanges();
            }
        }
    }
}
