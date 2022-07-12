using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;
namespace Models

{

    public class HowItWorksPageModel : BaseSeleniumPageModel
    {
         /// <summary>
        /// Initializes a new instance of the <see cref="HomePageModel" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public HowItWorksPageModel(ISeleniumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// Gets About Page 
        /// </summary>
        private LazyElement HIWPageButton
        {
            get { return this.GetLazyElement(By.CssSelector("#HowWork"), "How it Works page"); }
        }
        
        public void NavigatetoHIWPage()
        {
            this.HIWPageButton.Click();
        }

        // <summary>
        /// Gets About Page 
        /// </summary>
        private LazyElement HIWPageDetails
        {
            get { return this.GetLazyElement(By.CssSelector("#HowWorks"), "How it Works Page"); }
        }

        /// <summary>
        /// Check if the home page has been loaded
        /// </summary>
        /// <returns>True if the page was loaded</returns>
        public override bool IsPageLoaded()
        {
            return this.HIWPageDetails.Displayed;
        }

        
    }
}