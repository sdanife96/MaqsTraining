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
        /// Open page test
        /// </summary>
        [Test]
        public void OpenLoginPageTestNUnit()
        {
            LoginPageModel page = new LoginPageModel(this.TestObject);
            page.OpenLoginPage();
        }
    }
}
