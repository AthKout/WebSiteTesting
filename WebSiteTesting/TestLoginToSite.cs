using OpenQA.Selenium;

namespace WebSiteTesting
{
    [TestFixture]
    public class TestLoginToSite : BaseTest
    {
        [Test]
        [Description("Test case to validate the login functionality, using legit credentials.")]
        public void LoginToSiteMethod()
        {
            // Login with the right credentials
            LogIn();
            Thread.Sleep(TIMEOUT_SHORT);
            wait.Until(c => c.FindElement(By.CssSelector(".title")));
            IWebElement title = driver.FindElement(By.CssSelector(".title"));
            Assert.IsTrue(title.Text.Contains("Products"));
        }
    }
}
