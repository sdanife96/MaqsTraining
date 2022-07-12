using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;
namespace Models

{
    public class AboutPageModel : BaseSeleniumPageModel
    {
         /// <summary>
        /// Initializes a new instance of the <see cref="HomePageModel" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public AboutPageModel(ISeleniumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// Gets About Page 
        /// </summary>
        private LazyElement AboutPageButton
        {
            get { return this.GetLazyElement(By.CssSelector("#About"), "About"); }
        }
        
        public void NavigatetoAboutPage()
        {
            this.AboutPageButton.Click();
        }

        // <summary>
        /// Gets About Page 
        /// </summary>
        private LazyElement AboutTableDetails
        {
            get { return this.GetLazyElement(By.CssSelector("#AboutTable"), "About Details"); }
        }

        /// <summary>
        /// Check if the home page has been loaded
        /// </summary>
        /// <returns>True if the page was loaded</returns>
        public override bool IsPageLoaded()
        {
            return this.AboutTableDetails.Displayed;
        }

        
    }
}