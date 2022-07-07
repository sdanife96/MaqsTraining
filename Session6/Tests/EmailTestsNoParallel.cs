using CognizantSoftvision.Maqs.BaseEmailTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Tests
{
    /// <summary>
    /// Sample test class
    /// </summary>
    [TestClass]
    public class EmailTestsNoParallel : BaseEmailTest
    {
        /// <summary>
        /// Sample test
        /// </summary>
        [TestMethod]
        [DoNotParallelize]
        public void SampleTest()
        {
            Thread.Sleep(10000);
            // TODO: Update email connection configuration and add test code
            //Assert.IsTrue(this.EmailDriver.CanAccessEmailAccount(), "Could not access account");

            this.Log.LogMessage("Dummy test");
        }
    }
}
