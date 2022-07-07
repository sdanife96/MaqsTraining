using CognizantSoftvision.Maqs.BaseDatabaseTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    /// <summary>
    /// Tests test class with VSUnit
    /// </summary>
    [TestClass]
    public class DatabaseTestVSUnit : BaseDatabaseTest
    {
        /// <summary>
        /// Sample test
        /// </summary>
        [TestMethod]
        public void JustRows()
        {
            IEnumerable<dynamic> table = DatabaseDriver.Query("SELECT * FROM users");
            Assert.AreEqual(10, table.Count(), "Expected 10 rows");
        }

        [TestMethod]
        public void NotDefined()
        {
            IEnumerable<dynamic> table = DatabaseDriver.Query("SELECT * FROM users");

            foreach (dynamic row in table)
            {
                Console.WriteLine(row.FirstName);
                Console.WriteLine(row.LastName);
                Console.WriteLine(row.Id);

                if (row.Id == 10)
                {
                    return;
                }
            }

            Assert.Fail("Failed to find user 10");
        }

        [TestMethod]
        public void NotDefined2()
        {
            IEnumerable<dynamic> account = DatabaseDriver.Query<dynamic>(@"
                    SELECT Id, FirstName, LastName
                    FROM users");

            foreach (dynamic row in account)
            {
                Console.WriteLine(row.FirstName);
                Console.WriteLine(row.LastName);
                Console.WriteLine(row.Id);

                if (row.Id == 10)
                {
                    return;
                }
            }

            Assert.Fail("Failed to find user 10");
        }

        [TestMethod]
        public void MappedEnumerable()
        {
            IEnumerable<User> table = DatabaseDriver.Query<User>("SELECT * FROM users");

            foreach (User user in table)
            {
                Console.WriteLine(user.FirstName);
                Console.WriteLine(user.LastName);
                Console.WriteLine(user.Id);

                if (user.Id == 10)
                {
                    return;
                }
            }

            Assert.AreEqual(10, table.Count(), "Expected 10 tables");
        }

        [TestMethod]
        public void MappedList()
        {
            List<User> table = DatabaseDriver.Query<User>("SELECT * FROM users").ToList();

            foreach (User user in table)
            {
                Console.WriteLine(user.FirstName);
                Console.WriteLine(user.LastName);
                Console.WriteLine(user.Id);

                if (user.Id == 10)
                {
                    return;
                }
            }

            Assert.AreEqual(10, table.Count, "Expected 10 tables");
        }

        [TestMethod]
        public void Insert()
        {
            // How many NewProd items do we expect
            int expectedCountAfterInsert = DatabaseDriver.Query<User>("SELECT Id FROM 'products' where ProductName='NewProd'").ToList().Count + 1;

            Product newProduct = new Product
            {
                ProductName = "NewProd"
            };

            // Insert the new product
            this.DatabaseDriver.Insert(newProduct);

            // Make sure we have the correct number of NewProd elements
            Assert.AreEqual(expectedCountAfterInsert, DatabaseDriver.Query<User>("SELECT Id FROM 'products' where ProductName='NewProd'").ToList().Count);
        }
    }
}
