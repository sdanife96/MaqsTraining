using CognizantSoftvision.Maqs.BaseWebServiceTest;
using NUnit.Framework;
using WebServiceModel;

namespace Tests
{
    /// <summary>
    /// Simple web service test class using NUnit
    /// </summary>
    [TestFixture]
    public class WebServiceTestNUnit : BaseWebServiceTest
    {
        /// <summary>
        /// Get single product as XML
        /// </summary>
        [Test]
        public void GetXmlDeserializedNUnit()
        {
            ProductXml result = this.WebServiceDriver.Get<ProductXml>("/api/XML_JSON/GetProduct/1", "application/xml", false);

            Assert.AreEqual(1, result.Id, "Expected to get product 1");
        }

        /// <summary>
        /// Get single product as Json
        /// </summary>
        [Test]
        public void GetJsonDeserializedNUnit()
        {
            ProductJson result = this.WebServiceDriver.Get<ProductJson>("/api/XML_JSON/GetProduct/1", "application/json", false);

            Assert.AreEqual(1, result.Id, "Expected to get product 1");
        }


       //////XML AND JSON THATS GETS fFROM GET ALL PRODUCTS API 

        /// <summary>
        /// Get array  product as XML
        /// </summary>
        [Test]
        public void GetArrayXmlDeserializedNUnit()
        {
            ProductXml result = this.WebServiceDriver.Get<ProductXml>("/api/XML_JSON/GetAllProducts", "application/xml", false);

            Assert.AreEqual(1, result.arrayProducts, "Expected to get all products in Array");
        }

        /// <summary>
        /// Get array  product as XML
        /// </summary>
        [Test]
        public void GetArrayJsonDeserializedNUnit()
        {
            ProductJson result = this.WebServiceDriver.Get<ProductJson>("/api/XML_JSON/GetAllProducts", "application/xml", false);

            Assert.AreEqual(1, result.arrayProducts, "Expected to get all products in Array");
        }

    }
}
