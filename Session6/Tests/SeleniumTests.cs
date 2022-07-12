
using CognizantSoftvision.Maqs.BaseSeleniumTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
namespace Tests
{
    /// <summary>
    /// Composite Selenium test class
    /// </summary>

    [TestClass]
    public class SeleniumTests : BaseSeleniumTest
    {
        [DataTestMethod]
        [TestCategory("DataDriven")]
        [DataRow("Ted","12345")]
        [DataRow("Ted","1234")]
        [DataRow("Ted","123456")]
        [DataRow("Ted","123qwe")]
        [DataRow("Ted","qwerty")]
        [DataRow("Ted","123")]
        [TestMethod]
        public void NavigatetoTraining2Site(string userName, string password)
        {
            
             LoginPageModel page = new LoginPageModel(this.TestObject);
             page.OpenLoginPage();
             page.LoginWithInvalid_ValidCredentials(userName,password);
             Assert.IsTrue(page.IsPageLoaded());

             HowItWorksPageModel hiw = new HowItWorksPageModel(this.TestObject);
             hiw.NavigatetoHIWPage();
             Assert.IsTrue(hiw.IsPageLoaded());

             AsyncPageModel async = new AsyncPageModel(this.TestObject);
             async.NavigatetoAsyncPage();
             Assert.IsTrue(async.IsPageLoaded());

             AboutPageModel about = new AboutPageModel(this.TestObject);
             about.NavigatetoAboutPage();
             Assert.IsTrue(about.IsPageLoaded());

        }
    }
}
