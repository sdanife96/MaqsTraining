using CognizantSoftvision.Maqs.BaseTest;
using CognizantSoftvision.Maqs.Utilities.Helper;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    /// <summary>
    /// BasicNUnitTest test class with NUnit
    /// </summary>
    [TestFixture]
    public class NUnitDataDrivenTests : BaseTest
    {
        /// <summary>
        /// Sample test
        /// </summary>
        [TestCase(1, 1, 2, TestName = "One plus one")]
        [TestCase(1, 2, 3, TestName = "One plus two")]
        [TestCase(0, 1, 1, TestName = "Zero plus one")]
        [Category("DataDriven")]
        [Category(TestCategories.NUnit)]
        public void AddsUpTestCase(int firstNumber, int secondNumber, int sum)
        {
            this.TestObject.Log.LogMessage("Start Test");
            Assert.AreEqual(sum, firstNumber + secondNumber);
        }

        /// <summary>
        /// Sample test
        /// </summary>
        [Test]
        [Category("DataDriven")]
        [Category(TestCategories.NUnit)]
        [TestCaseSource("AddUp")]
        public void AddsUpIEnumerable(int firstNumber, int secondNumber, int sum)
        {
            this.TestObject.Log.LogMessage("Start Test");
            Assert.AreEqual(sum, firstNumber + secondNumber);
        }

        public static IEnumerable<int[]> AddUp
        {
            get
            {
                yield return new int[] { 1, 1, 2 };
                yield return new int[] { 10, 11, 21 };
                yield return new int[] { -1, 1, 0 };
            }
        }
    }
}