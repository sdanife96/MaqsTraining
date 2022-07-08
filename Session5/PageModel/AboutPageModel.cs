using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for the Automation page
    /// </summary>
    public class AboutPageModel : BaseSeleniumPageModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AboutPageModel" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public AboutPageModel(ISeleniumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// Gets welcome message
        /// </summary>
        private LazyElement WelcomeMessage
        {
            get { return this.GetLazyElement(By.CssSelector("#WelcomeMessage"), "Welcome message"); }
        }

        private LazyElement AboutPage
        {
            get { return this.GetLazyElement(By.CssSelector("#About"),"About Navigation Tab"); }
        }

        /// <summary>
        /// Check if the home page has been loaded
        /// </summary>
        /// <returns>True if the page was loaded</returns>
        public override bool IsPageLoaded()
        {
            return this.WelcomeMessage.Displayed;
        }

        /// <summary>
        /// Click on google logo
        /// </summary>
        public void ClickonAboutButton()
        {
            this.AboutPage.Click();
        }

        /// <summary>
        /// Gets the doodle element
        /// </summary>
        private LazyElement AboutPageDisplay
        {
            get { return this.GetLazyElement(By.CssSelector("#AboutTable"), "About Table Info is displayed"); }
        }

        /// <summary>
        /// Check if the page has been loaded
        /// </summary>
        /// <returns>True if the page was loaded</returns>
        public bool IsAboutPageLoaded()
        {
            return this.AboutPageDisplay.Displayed;      
        }


    }
}

