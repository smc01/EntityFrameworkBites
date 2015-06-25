using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

using EntityFrameworkBites.DataModel;
using EntityFrameworkBites.Entities;
using EntityFrameworkBites.Services.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Respawn;

namespace EntityFrameworkBites.IntegrationTests
{
    [TestClass]
    public class RepositoryTests
    {
        private readonly SqlConnection _sqlConnection;
        private readonly Checkpoint _checkPoint;

        public RepositoryTests()
        {
            var connString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString; ;
            _sqlConnection = new SqlConnection(connString);


            _checkPoint = new Checkpoint
            {
                DbAdapter = DbAdapter.SqlServer,
                TablesToIgnore = new[] { "ProductCategory", "VersionInfo" },
            };
        }

        [TestInitialize]
        public void SetUpTests()
        {
            _sqlConnection.Open();
        }

        [TestCleanup]
        public void CleanUpTests()
        {
            _checkPoint.Reset(_sqlConnection);
            _sqlConnection.Close();
        }

        [TestMethod]
        public void ShouldInsertOrUpdateSuccessfully()
        {
            using (var dbEntities = new DbEntities())
            {
                var repository = new GenericRepository<Product>(dbEntities);
                repository.InsertOrUpdate(new Product() { Name = "Vasile" });

                dbEntities.SaveChanges();

                var records = repository.All().Count();
                Assert.AreEqual(records, 1);


            }
        }

        [TestMethod]
        public void SingleTest()
        {
            using (var dbEntities = new DbEntities())
            {
                var fixture = new Fixture();

                var entities = fixture.CreateMany<Product>(4);

                var repository = new GenericRepository<Product>(dbEntities);
                
                entities.ToList().ForEach(p=>repository.InsertOrUpdate(new Product()
                {
                    Name = p.Name
                }));
                dbEntities.SaveChanges();
                var counter = repository.All().Count();
                Assert.AreEqual(counter,entities.Count());
            }

        }
    }
}
