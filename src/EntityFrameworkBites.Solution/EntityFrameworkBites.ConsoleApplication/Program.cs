using System;
using System.Runtime.InteropServices.WindowsRuntime;
using EntityFrameworkBites.DataModel;
using EntityFrameworkBites.Entities;
using EntityFrameworkBites.Services.Repositories;

namespace EntityFrameworkBites.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var dbEntities = new DbEntities())
            {
                var repository = new GenericRepository<Product>(dbEntities);
                repository.InsertOrUpdate(new Product() { Name = "Vasile" });

                dbEntities.SaveChanges();

            }



            var entity = new Product() {Id = 1, Name = "vasilescu"};

            using (var dbEntities = new DbEntities())
            {
                var repository = new GenericRepository<Product>(dbEntities);
                repository.InsertOrUpdate(entity);

                dbEntities.SaveChanges();
                Console.WriteLine(entity.Name);
            }





        }
    }
}
