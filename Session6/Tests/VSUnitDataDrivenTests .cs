using CognizantSoftvision.Maqs.BaseTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests
{
    /// <summary>
    /// BasicVSUnitDemo6 test class with VSUnit
    /// </summary>
    [TestClass]
    public class VSUnitDataDrivenTests : BaseTest
    {
        /// <summary>
        /// Sample test
        /// </summary>
        [TestMethod]
        [TestCategory("DataDriven")]
        [DataRow(1, 1, 2)]
        [DataRow(1, 2, 3)]
        [DataRow(-1, 1, 0)]
        [DataRow(0, 0, 0)]
        public void AddsUpDataRows(int firstNumber, int secondNumber, int sum)
        {
            this.TestObject.Log.LogMessage("Start Test");
            Assert.AreEqual(sum, firstNumber + secondNumber);
        }

        /// <summary>
        /// Sample test
        /// </summary>
        [DataTestMethod]
        [TestCategory("DataDriven")]
        [DynamicData(nameof(AddUp), DynamicDataSourceType.Property)]
        public void AddsUpIEnumerable(int firstNumber, int secondNumber, int sum)
        {
            this.TestObject.Log.LogMessage("Start Test");
            Assert.AreEqual(sum, firstNumber + secondNumber);
        }

        public static IEnumerable<object[]> AddUp
        {
            get
            {
                yield return new object[] { 1, 1, 2 };
                yield return new object[] { 10, 11, 21 };
                yield return new object[] { -1, 1, 0 };
            }
        }

        [DataTestMethod]
        [TestCategory("DataDriven")]
        [DataRow("Ted","12345")]
        [DataRow("Ted","1234")]
        [DataRow("Ted","123456")]
        [DataRow("Ted","123qwe")]
        [DataRow("Ted","qwerty")]
        [DataRow("Ted","123")]
        public void InvalidLoginDatas(string username, string password)
        {
            this.TestObject.Log.LogMessage("Start Test Invalid Login");
           
        }

    }
}