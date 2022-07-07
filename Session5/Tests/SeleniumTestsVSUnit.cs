using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using CognizantSoftvision.Maqs.Utilities.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PageModel;

namespace Tests
{
    /// <summary>
    /// SeleniumTest test class with VS unit
    /// </summary>
    [TestClass]
    public class SeleniumTestsVSUnit : BaseSeleniumTest
    {

        /// <summary>
        /// Verify TryWaitForVisibleElement wait works
        /// </summary>
        [TestMethod]
        public void DirectAccessWithWait()
        {
            this.WebDriver.Navigate().GoToUrl("https://magenicautomation.azurewebsites.net/Automation/AsyncPage");
            bool found = WebDriver.Wait().TryForVisibleElement(By.CssSelector("#loading-div-text[style='display: block;']"), out IWebElement element);

            Assert.IsTrue(found, "False was returned");
            Assert.AreEqual("Loaded", element.Text, "Null element was returned");
        }

        /// <summary>
        /// Enter credentials test
        /// </summary>
        [TestMethod]
        public void EnterValidCredentialsTestNoUndelyingLazy()
        {
            LoginPageModel page = new LoginPageModel(this.TestObject);
            page.OpenLoginPage();

            // Call without lazy
            HomePageModel homepage = page.LoginWithValidCredentialsNoLazy("Ted", "123");

            Assert.IsTrue(homepage.IsPageLoaded());
        }

        /// <summary>
        /// Enter credentials test
        /// </summary>
        [TestMethod]
        public void EnterValidCredentialsTest()
        {
            string username = "Ted";
            string password = "123";
            LoginPageModel page = new LoginPageModel(this.TestObject);
            page.OpenLoginPage();
            
            // Suppress logging while preforming login
            this.Log.SuspendLogging();
            HomePageModel homepage = page.LoginWithValidCredentials(username, password);
            this.Log.ContinueLogging();

            // Add new log content
            this.Log.LogMessage(MessageType.SUCCESS, "Login did not throw error");

            Assert.IsTrue(homepage.IsPageLoaded());
        }

        /// <summary>
        /// Soft assert with logging
        /// </summary>
        [TestMethod]
        public void SoftAssertWithLoggingFailures()
        {
            string username = "WrongTed";
            string password = "123";
            LoginPageModel page = new LoginPageModel(this.TestObject);
            page.OpenLoginPage();

            // Demo soft assert failure 1
            this.SoftAssert.Assert(() => Assert.IsTrue(false, "Cause soft assert error for demo."));

            // Suppress logging while preforming login
            HomePageModel homepage = page.LoginWithValidCredentials(username, password);

            // Demo soft assert failure 2
            this.SoftAssert.Assert(() => Assert.IsTrue(homepage.IsPageLoaded(), "Home page was not loaded."));
        }

        /// <summary>
        /// Use multiple drivers in the same test
        /// </summary>
        [TestMethod]
        public void MultipleDrivers()
        {
            // Define named driver 1
            this.ManagerStore.AddOrOverride("ExtraDriver1", new SeleniumDriverManager(() =>
                 WebDriverFactory.GetBrowserWithDefaultConfiguration(SeleniumConfig.GetBrowserType()), this.TestObject));

            // Define named driver 2
            this.ManagerStore.AddOrOverride("ExtraDriver2", new SeleniumDriverManager(() =>
                 WebDriverFactory.GetBrowserWithDefaultConfiguration(SeleniumConfig.GetBrowserType()), this.TestObject));

            // Open login page with default driver
            LoginPageModel page = new LoginPageModel(this.TestObject);
            page.OpenLoginPage();

            // Nagivate with named driver 1
            this.ManagerStore.GetDriver<IWebDriver>("ExtraDriver1").Navigate().GoToUrl("https://www.google.com");

            // Nagivate with named driver 1
            this.ManagerStore.GetDriver<IWebDriver>("ExtraDriver2").Navigate().GoToUrl("https://www.cognizantsoftvision.com");

            // Test default driver
            Assert.IsTrue(page.LoginWithInvalidCredentials("NOT", "Valid"));

            // Test named driver
            Assert.IsTrue(this.ManagerStore.GetDriver<IWebDriver>("ExtraDriver1").Url.Contains("google"));

            // Test named driver
            Assert.IsTrue(this.ManagerStore.GetDriver<IWebDriver>("ExtraDriver2").Url.Contains("softvision"));

            // Remove during a test run
            this.ManagerStore.Remove("ExtraDriver2");
        }
    }
}
