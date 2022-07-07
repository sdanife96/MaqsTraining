using CognizantSoftvision.Maqs.BaseDatabaseTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    /// <summary>
    /// Sample test class
    /// </summary>
    [TestClass]
    public class DatabaseTests : BaseDatabaseTest
    {
        /// <summary>
        /// Sample test
        /// </summary>
        [TestMethod]
        public void SampleTest()
        {
            IEnumerable<dynamic> table = this.DatabaseDriver.Query("SELECT * FROM users");
            Assert.AreEqual(10, table.Count(), "Expected 10 rows");
        }
    }
}
