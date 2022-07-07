using CognizantSoftvision.Maqs.BaseEmailTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    /// <summary>
    /// Email test class
    /// </summary>
    [TestClass]
    public class Email : BaseEmailTest
    {
        /// <summary>
        /// Sample test
        /// </summary>
        [TestMethod]
        public void CannotAccess()
        {
            try
            {
                this.EmailDriver.CanAccessEmailAccount();
                Assert.Fail("Should not be able to access account");
            }
            catch (Exception e)
            {
                // Connection should be refused
                Assert.IsTrue(e.Message.Contains("refused"));
            }
        }
    }
}
