
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
         /// <summary>
        /// Do the class setup 
        /// </summary>
        public static void TestSetup(TestContext context)
        {
            System.Console.WriteLine("Class Setup");
        }

        [TestMethod]
        [DataTestMethod]
        [TestCategory("DataDriven")]
        [DataRow("Ted","12345")]
        [DataRow("Ted","1234")]
        [DataRow("Ted","123456")]
        [DataRow("Ted","123qwe")]
        [DataRow("Ted","qwerty")]
        public void DataDrivenTestInvalidData(string userName, string password)
        {

             LoginPageModel page = new LoginPageModel(this.TestObject);
             page.OpenLoginPage();
             page.LoginWithInvalidCredentials(userName,password);

        }


        [TestMethod]
        public void NavigatetoTraining2Site()
        {


             LoginPageModel page = new LoginPageModel(this.TestObject);
             page.OpenLoginPage();
             page.LoginWithValidCredentials("Ted","123");

             HowItWorksPageModel hiw = new HowItWorksPageModel(this.TestObject);
             hiw.NavigatetoHIWPage();

             AsyncPageModel async = new AsyncPageModel(this.TestObject);
             async.NavigatetoAsyncPage();

             AboutPageModel about = new AboutPageModel(this.TestObject);
             about.NavigatetoAboutPage();

        }
        
        public void TeardownSetup()
        {
            System.Console.WriteLine("Function Teardown");

        }
    }
}
