using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Respawn;

namespace EntityFrameworkBites.UnitTesting
{
    [TestClass]
    public class UnitTest1
    {

        private static Checkpoint checkpoint = new Checkpoint
        {
            TablesToIgnore = new[]
            {
                "sysdiagrams",
                "tblUser",
                "tblObjectType",
            },
                    SchemasToExclude = new[]
            {
                "RoundhousE"
            },
            DbAdapter = DbAdapter.SqlServer
        };

        [TestInitialize]
        public void StartTest()
        {
            
        }

        [TestMethod]
        public void TestMethod1()
        {
            checkpoint.

        }
    }
}
