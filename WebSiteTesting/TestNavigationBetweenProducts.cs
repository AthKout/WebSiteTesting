using OpenQA.Selenium;

namespace WebSiteTesting
{
    [TestFixture]
    public class TestNavigationBetweenProducts : BaseTest
    {
        [Test]
        [Description("Test case to validate the navigation between different products.")]
        public void NavigateBetweenProductsMethod()
        {
            // Login to the site
            LogIn();
            // Navigate between products
            IWebElement product1 = wait.Until(c => c.FindElement(By.CssSelector("#item_4_title_link")));
            product1.Click();
            Thread.Sleep(TIMEOUT_SHORT);
            IWebElement backtoProducts1 = wait.Until(c => c.FindElement(By.CssSelector("#back-to-products")));
            backtoProducts1.Click();
            Thread.Sleep(TIMEOUT_SHORT);
            IWebElement product2 = wait.Until(c => c.FindElement(By.CssSelector("#item_0_title_link")));
            product2.Click();
            Thread.Sleep(TIMEOUT_SHORT);
            IWebElement backtoProducts2 = wait.Until(c => c.FindElement(By.CssSelector("#back-to-products")));
            backtoProducts2.Click();
            Thread.Sleep(TIMEOUT_SHORT);
            IWebElement product3 = wait.Until(c => c.FindElement(By.CssSelector("#item_1_title_link")));
            product3.Click();
            Thread.Sleep(TIMEOUT_SHORT);
            IWebElement backtoProducts3 = wait.Until(c => c.FindElement(By.CssSelector("#back-to-products")));
            backtoProducts3.Click();
            Thread.Sleep(TIMEOUT_LONG);
            Assert.IsTrue(driver.Url.Contains("inventory.html"));
        }
    }
}
