using CognizantSoftvision.Maqs.BaseSeleniumTest;
using NUnit.Framework;
using PageModel;

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
            string username = "Ted";
            string password = "123";
            LoginPageModel page = new LoginPageModel(this.TestObject);
            page.OpenLoginPage();
            HomePageModel homepage = page.LoginWithValidCredentials(username, password);
            Assert.IsTrue(homepage.IsPageLoaded());
        }
    }
}
