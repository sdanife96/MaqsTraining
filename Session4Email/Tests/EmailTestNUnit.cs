﻿using CognizantSoftvision.Maqs.BaseEmailTest;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Tests test class
    /// </summary>
    [TestFixture]
    public class EmailTestNUnit : BaseEmailTest
    {
        /// <summary>
        /// Sample test
        /// </summary>
        [Test]
        public void SampleTestNUnit()
        {
            // TODO: Update email connection configuration and add test code
            //Assert.IsTrue(this.EmailDriver.CanAccessEmailAccount(), "Could not access account");

            this.Log.LogMessage("Dummy test");
        }
    }
}