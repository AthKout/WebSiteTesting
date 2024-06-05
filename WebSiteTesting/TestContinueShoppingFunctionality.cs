using OpenQA.Selenium;

namespace WebSiteTesting
{
    [TestFixture]
    public class TestContinueShoppingFunctionality : BaseTest
    {

        [Test]
        [Description("Test case to validate the continue shopping functionality after adding an item to the cart.")]
        public void ContinueShopping()
        {
            // Login to the site
            LogIn(); 
            Thread.Sleep(TIMEOUT_LONG);
            // Click on the first product
            IWebElement inventory_item = wait.Until(c => c.FindElement(By.CssSelector(".inventory_item")));
            inventory_item.Click();
            Thread.Sleep(TIMEOUT_LONG);
            // Click on the Add to Cart button
            IWebElement btn_primary = wait.Until(c => c.FindElement(By.CssSelector(".btn_primary.btn_inventory")));
            btn_primary.Click();
            Thread.Sleep(TIMEOUT_LONG);
            // Wait for the shopping cart badge to update
            wait.Until(c=>c.FindElement(By.CssSelector(".shopping_cart_badge")));
            Thread.Sleep(TIMEOUT_LONG);
            // Click on the shopping cart icon
            IWebElement shopping_cart_link = wait.Until(c => c.FindElement(By.CssSelector(".shopping_cart_link")));
            shopping_cart_link.Click();
            Thread.Sleep(TIMEOUT_LONG);
            // Click on the Continue Shopping button
            IWebElement btn_medium = wait.Until(c => c.FindElement(By.CssSelector(".btn_medium")));
            btn_medium.Click();
            Thread.Sleep(TIMEOUT_LONG);
            // Verify that the user is redirected back to the Products page
            Assert.IsTrue(driver.Url.Contains("inventory.html"), "User is not redirected back to the Products page after Continue Shopping");
        }
    }
}
