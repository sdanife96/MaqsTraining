using CognizantSoftvision.Maqs.BaseWebServiceTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebServiceModel;

namespace Tests
{
    /// <summary>
    /// Simple web service test class using VS unit
    /// </summary>
    [TestClass]
    public class WebServiceTestVSUnit : BaseWebServiceTest
    {
        /// <summary>
        /// Get single product as XML
        /// </summary>
        [TestMethod]
        public void GetXmlDeserialized()
        {
            ProductXml result = this.WebServiceDriver.Get<ProductXml>("/api/XML_JSON/GetProduct/1", "application/xml", false);

            Assert.AreEqual(1, result.Id, "Expected to get product 1");
        }

        /// <summary>
        /// Get single product as Json
        /// </summary>
        [TestMethod]
        public void GetJsonDeserialized()
        {
            ProductJson result = this.WebServiceDriver.Get<ProductJson>("/api/XML_JSON/GetProduct/1", "application/json", false);

            Assert.AreEqual(1, result.Id, "Expected to get product 1");
        }

        //////XML AND JSON THATS GETS fFROM GET ALL PRODUCTS API 

        /// <summary>
        /// Get array  product as XML
        /// </summary>
        [TestMethod]
        public void GetArrayXmlDeserializedNUnit()
        {
            ProductXml result = this.WebServiceDriver.Get<ProductXml>("/api/XML_JSON/GetAllProducts", "application/xml", false);

            Assert.AreEqual(1, result.arrayProducts, "Expected to get all products in Array");
        }

        /// <summary>
        /// Get array  product as XML
        /// </summary>
        [TestMethod]
        public void GetArrayJsonDeserializedNUnit()
        {
            ProductJson result = this.WebServiceDriver.Get<ProductJson>("/api/XML_JSON/GetAllProducts", "application/xml", false);

            Assert.AreEqual(1, result.arrayProducts, "Expected to get all products in Array");
        }

    }
}
