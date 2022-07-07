using CognizantSoftvision.Maqs.BaseWebServiceTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Text;
using WebServiceModel;

namespace Tests
{
    /// <summary>
    /// WithAuth test class
    /// </summary>
    [TestClass]
    public class WebServiceApiTests : BaseTripTests
    {
        [TestMethod]
        public void GetUsersAsString()
        {
            var response = this.WebServiceDriver.Get("authTripsAPI/users", "application/json");
            Assert.IsTrue(response.Contains("userId"), "Body should contain 'userId'");
        }

        [TestMethod]
        public void GetTripsAsObject()
        {
            var response = this.WebServiceDriver.Get<Trip[]>("authTripsAPI/1/trips", "application/json");
            Assert.AreEqual("NewYork Trip", response[0].name, "Wrong trip");
        }

        [TestMethod]
        public void GetTripWithResponse()
        {
            var response = this.WebServiceDriver.GetWithResponse("authTripsAPI/1/trips/1", "application/json", HttpStatusCode.OK);
            Trip result = WebServiceUtils.DeserializeJson<Trip>(response);
            Assert.AreEqual("NewYork Trip", result.name, "Wrong trip");
        }

        [TestMethod]
        public void PostNewTrip()
        {
            Trip newTrip = new Trip
            {
                name = "Testing",
                description = "Testing data"
            };

            var requestBody = WebServiceUtils.MakeStringContent(newTrip, Encoding.UTF8, "application/json");
            var response = this.WebServiceDriver.Post<Trip>("authTripsAPI/1/trips/", "application/json", requestBody);
            Assert.AreEqual(0, response.numberOfStops, "New trip should start with no stops");
        }
        

        [TestMethod]
        public void BadDelete()
        {
            var response = this.WebServiceDriver.DeleteWithResponse("authTripsAPI/-1/trips/-1", "application/json", false);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode, "Expected 404");
        }
    }
}
