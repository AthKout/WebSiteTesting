using OpenQA.Selenium;

namespace WebSiteTesting
{
    [TestFixture]
    public class TestAddItemToCart : BaseTest
    {
        [Test]
        [Description("Test case to validate the functionality of adding an item to the cart.")]
        public void AddItemToCart()
        {
            // Login to the site 
            LogIn();
            // Wait for the Add to Cart button to be clickable
            IWebElement addToCartButton = wait.Until(c => c.FindElement(By.CssSelector(".btn_primary.btn_inventory")));
            // Click on the Add to Cart button
            addToCartButton.Click(); 
            Thread.Sleep(TIMEOUT_LONG);
            // Wait for the shopping cart badge to be visible
            IWebElement shoppingCartBadge = wait.Until(c => c.FindElement(By.CssSelector(".shopping_cart_badge")));
            // Verify item added to cart
            Assert.IsTrue(shoppingCartBadge.Text as string == "1");
        }
    }
}
