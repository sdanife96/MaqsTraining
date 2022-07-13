﻿using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Models
{
    /// <summary>
    /// Page object for the Automation page
    /// </summary>
    public class LoginPageModel : BaseSeleniumPageModel
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static string PageUrl = SeleniumConfig.GetWebSiteBase() + "Static/Training2/loginpage.html";

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPageModel" /> class.
        /// </summary>
        /// <param name="testObject">The test object</param>
        public LoginPageModel(ISeleniumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// Gets user name box
        /// </summary>
        private LazyElement UserNameInput
        {
            get { return this.GetLazyElement(By.CssSelector("#UserName"), "User name input"); }
        }

        /// <summary>
        /// Gets password box
        /// </summary>
        private LazyElement PasswordInput
        {
            get { return this.GetLazyElement(By.CssSelector("#Password"), "Password input"); }
        }

        /// <summary>
        /// Gets login button
        /// </summary>
        private LazyElement LoginButton
        {
            get { return this.GetLazyElement(By.CssSelector("#Login"), "Login button"); }
        }

        /// <summary>
        /// Gets error message
        /// </summary>
        private LazyElement ErrorMessage
        {
            get { return this.GetLazyElement(By.CssSelector("#LoginError"), "Invalid name or password"); }
        }

        /// <summary>
        /// Open the login page
        /// </summary>
        public void OpenLoginPage()
        {
            this.TestObject.WebDriver.Navigate().GoToUrl(PageUrl);
            this.AssertPageLoaded();
        }

        /// <summary>
        /// Enter the use credentials
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The user password</param>
        public void EnterCredentials(string userName, string password)
        {
            this.UserNameInput.SendKeys(userName);
            this.PasswordInput.SendKeys(password);
        }

        
        /// <summary>
        /// Enter the use credentials and log in - Navigation sample
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The user password</param>
        /// <returns>The home page</returns>
        [DataTestMethod]
        [TestCategory("DataDriven")]
        [DataRow("Ted","123")]
        public HomePageModel LoginWithValidCredentials(string userName, string password)
        {
            this.EnterCredentials(userName, password);
            this.LoginButton.Click();

            return new HomePageModel(this.TestObject);
        }

        [DataTestMethod]
        [TestCategory("DataDriven")]
        [DataRow("Ted","12345")]
        [DataRow("Ted","1234")]
        [DataRow("Ted","123456")]
        [DataRow("Ted","123qwe")]
        [DataRow("Ted","qwerty")]
        public HomePageModel LoginWithInvalidCredentials(string userName, string password)
        {
            this.EnterCredentials(userName, password);
            this.LoginButton.Click();
            if(ErrorMessage.Displayed)
            {
                Assert.IsTrue(ErrorMessage.Displayed);
            }else if(!ErrorMessage.Displayed){
                this.EnterCredentials("Ted", "123");
                this.LoginButton.Click();
            }
            Assert.IsTrue(ErrorMessage.Displayed);
            
            return new HomePageModel(this.TestObject);
        }



        /// <summary>
        /// Assert the login page loaded
        /// </summary>
        public void AssertPageLoaded()
        {
            Assert.IsTrue(
                this.IsPageLoaded(),
                "The web page '{0}' is not loaded",
                PageUrl);
        }

        /// <summary>
        /// Check if the home page has been loaded
        /// </summary>
        /// <returns>True if the page was loaded</returns>
        public override bool IsPageLoaded()
        {
            return this.UserNameInput.Displayed && this.PasswordInput.Displayed && this.LoginButton.Displayed;
        }
    }
}

