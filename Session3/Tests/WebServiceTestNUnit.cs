using CognizantSoftvision.Maqs.BaseWebServiceTest;
using NUnit.Framework;
using WebServiceModel;
using System.Collections.Generic;
using System;


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

        [Test]
        public void GetAllProductsAsObject()
        {
            
            var response = this.WebServiceDriver.Get<AllProducts[]>("/api/XML_JSON/GetAllProducts", "application/json");
            Console.WriteLine(response);
            if(response.Equals(0))
            {
                //Console.WriteLine(response);
                Assert.AreEqual("Tomato Soup", response[0].Name, "Incorrect Matched");
            }else if(response.Equals(1))
            {
                //Console.WriteLine(response);
                Assert.AreEqual("Yo-yo", response[1].Name, "Incorrect Matched");
            }else if(response.Equals(2))
            {
                 Assert.AreEqual("Hammer", response[2].Name, "Incorrect Matched");
            }
           
        }
        
    }
}