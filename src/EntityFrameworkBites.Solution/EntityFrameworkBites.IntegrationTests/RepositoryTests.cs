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

                var productCategory = repositoryProductCategory.Single(p => p.Id == 1);

                var product = _fixture.Create<Product>();
                product.ProductCategory = productCategory;
                product.ProductCategoryId = productCategory.Id;


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
                var fixture = new Fixture();
                var item = fixture.Create<Product>();

                var repository = new GenericRepository<Product>(dbEntities);
                var repositoryCategory = new GenericRepository<ProductCategory>(dbEntities);

                var category = repositoryCategory.Single(p => p.Id == 1);
                item.ProductCategory = category;
                item.ProductCategoryId = category.Id;

                repository.InsertOrUpdate(item);

                dbEntities.SaveChanges();
                var counter = repository.Single(p => p.Id == item.Id);
                Assert.IsNotNull(counter);
            }

        }
    }
}
