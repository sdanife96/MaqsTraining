using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;
namespace Models

{
    public class AsyncPageModel : BaseSeleniumPageModel
    {
         /// <summary>
        /// Initializes a new instance of the <see cref="HomePageModel" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public AsyncPageModel(ISeleniumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// Gets About Page 
        /// </summary>
        private LazyElement AsyncPageButton
        {
            get { return this.GetLazyElement(By.CssSelector("#Async"), "Async page"); }
        }
        
        public void NavigatetoAsyncPage()
        {
            this.AsyncPageButton.Click();
        }

        // <summary>
        /// Gets About Page 
        /// </summary>
        private LazyElement AsyncPageDetails
        {
            get { return this.GetLazyElement(By.CssSelector("#Label"), "Async Page"); }
        }

        /// <summary>
        /// Check if the home page has been loaded
        /// </summary>
        /// <returns>True if the page was loaded</returns>
        public override bool IsPageLoaded()
        {
            return this.AsyncPageDetails.Displayed;
        }

        
    }
}