using CognizantSoftvision.Maqs.BaseSeleniumTest;
using NUnit.Framework;
using PageModel;
using CognizantSoftvision.Maqs.Utilities.Helper;
using CognizantSoftvision.Maqs.Utilities.Logging;



namespace Tests
{
    /// <summary>
    /// SeleniumTest test class with NUnit
    /// </summary>
    [TestFixture]
    public class SeleniumTestsNUnit : BaseSeleniumTest
    {
        /// <summary>
        /// Enter credentials test
        /// </summary>
        [Test]
        public void EnterValidCredentialsTestNUnit()
        {
            //string username = "Ted";
            //string password = "123";

             // Grab values from configuration
            this.PerfTimerCollection.StartTimer("Login timer");
            string username = Config.GetGeneralValue("Username");
            string password = Config.GetGeneralValue("Password");

            LoginPageModel page = new LoginPageModel(this.TestObject);
            page.OpenLoginPage();
            HomePageModel homepage = page.LoginWithValidCredentials(username, password);
            Assert.IsTrue(homepage.IsPageLoaded());
        }
    }
}
