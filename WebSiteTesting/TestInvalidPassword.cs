using OpenQA.Selenium;

namespace WebSiteTesting
{
    [TestFixture]
    public class TestInvalidPassword : BaseTest
    {
        [Test]
        [Description("Test case to verify that an invalid password leads to a failed login attempt.")]
        public void ProvideInvalidPassword()
        {
            // Attempt to login with a false pasword
            LogIn(true);
            Thread.Sleep(TIMEOUT_LONG);
            wait.Until(c => c.FindElement(By.CssSelector(".error-message-container")));
            IWebElement errorMessage = driver.FindElement(By.CssSelector(".error-message-container"));
            Assert.IsTrue(errorMessage.Displayed, "Error message is displayed for invalid login.");
        }
    }
}
