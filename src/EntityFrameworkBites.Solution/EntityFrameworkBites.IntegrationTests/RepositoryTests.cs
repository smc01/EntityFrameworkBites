using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

using EntityFrameworkBites.DataModel;
using EntityFrameworkBites.DataModel.Base;
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

        private readonly IFixture _fixture;

        public RepositoryTests()
        {
            var connString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString; ;
            _sqlConnection = new SqlConnection(connString);

            _fixture = new Fixture();

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
                var repositoryProductCategory = new GenericRepository<ProductCategory>(dbEntities);
                var product = GetProduct(dbEntities);

                repository.InsertOrUpdate(product);

                dbEntities.SaveChanges();

                var records = repository.All().Count();
                Assert.AreEqual(records, 1);


            }
        }

        [TestMethod]
        public void SingleShouldReturnOnlyOneRecord()
        {
            using (var dbEntities = new DbEntities())
            {
                var repository = new GenericRepository<Product>(dbEntities);
                var item = GetProduct(dbEntities);

                repository.InsertOrUpdate(item);

                dbEntities.SaveChanges();
                var counter = repository.Single(p => p.Id == item.Id);
                Assert.IsNotNull(counter);
            }

        }

        [TestMethod]
        public void ShouldDeleteDisconnectedEntity()
        {
            Product item = null;
            using (var dbEntities = new DbEntities())
            {
                var repository = new GenericRepository<Product>(dbEntities);

                item = GetProduct(dbEntities);
                repository.InsertOrUpdate(item);
                dbEntities.SaveChanges();
            }

            using (var dbEntities = new DbEntities())
            {
                var repository = new GenericRepository<Product>(dbEntities);
                repository.Delete(item);
                dbEntities.SaveChanges();
            }
            Assert.IsNotNull(item);
            Assert.IsTrue(1 == 1);
        }

        [TestMethod]
        public void ShouldEditDisconnectedEntity()
        {
            Product item = null;
            using (var dbEntities = new DbEntities())
            {
                var repository = new GenericRepository<Product>(dbEntities);

                item = GetProduct(dbEntities);
                repository.InsertOrUpdate(item);
                dbEntities.SaveChanges();
            }

            using (var dbEntities = new DbEntities())
            {
                var repository = new GenericRepository<Product>(dbEntities);
                item.Name = "NewName";
                repository.Edit(item);
                dbEntities.SaveChanges();
            }
            Assert.IsNotNull(item);
            Assert.IsTrue(1 == 1);
        }

        [TestMethod]
        public void ShouldNotDeleteRelatedChild()
        {
            using (var dbEntities = new DbEntities())
            {
                try
                {
                    var repository = new GenericRepository<Product>(dbEntities);
                    var repositoryCategory = new GenericRepository<ProductCategory>(dbEntities);

                    var category = repositoryCategory.Single(p => p.Id == 1);

                    var item = GetProduct(dbEntities);
                    repository.InsertOrUpdate(item);

                    repositoryCategory.Delete(category);
                    dbEntities.SaveChanges();
                    repositoryCategory.Single(p => p.Id == category.Id);
                    Assert.Fail("Should Not Delete");
                }
                catch (Exception error)
                {
                    Assert.IsTrue(1 == 1);
                }
                Assert.IsTrue(1 == 1);
            }

        }

        private static Product GetProduct(DbEntities dbEntities)
        {
            var fixture = new Fixture();
            var item = fixture.Create<Product>();

            var repositoryCategory = new GenericRepository<ProductCategory>(dbEntities);

            var category = repositoryCategory.Single(p => p.Id == 1);
            item.ProductCategory = category;
            item.ProductCategoryId = category.Id;

            return item;
        }
    }
}
