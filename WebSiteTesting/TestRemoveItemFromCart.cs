using OpenQA.Selenium;

namespace WebSiteTesting
{
    public class TestRemoveItemFromCart : BaseTest
    {
        [Test]
        [Description("Test case to validate an item's removal from the cart.")]
        public void RemoveItemFromBasket()
        {
            // Presume that cart is not empty
            bool IsCartEmpty = false;
            // Login to the site
            LogIn();
            Thread.Sleep(TIMEOUT_MED);

            try
            {
                // If there is no badge element on the cart it means it is empty
                driver.FindElement(By.CssSelector(".shopping_cart_badge"));
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException)
                    IsCartEmpty = true;
            }

            if (IsCartEmpty)
            {
                // Add an item to the cart for testing removal
                IWebElement btn_inventory = wait.Until(c => c.FindElement(By.CssSelector(".btn_inventory")));
                btn_inventory.Click(); // Click on the first product
                Thread.Sleep(TIMEOUT_LONG);
            }
            IWebElement shopping_cart = wait.Until(c => c.FindElement(By.CssSelector(".shopping_cart_link")));
            shopping_cart.Click();
            Thread.Sleep(TIMEOUT_LONG);
            // Wait for the shopping cart badge to be visible
            IWebElement cartItem = wait.Until(c => c.FindElement(By.CssSelector(".cart_item")));
            // Verify item added to cart
            if (cartItem is not null)
                IsCartEmpty = false;

            // Remove the item from the cart
            IWebElement cart_btn = wait.Until(c => c.FindElement(By.CssSelector(".cart_button")));
            cart_btn.Click();
            Thread.Sleep(TIMEOUT_MED);
            // Verify that the cart is now empty
            IWebElement removedCartItem = wait.Until(c => c.FindElement(By.CssSelector(".removed_cart_item")));
            if (removedCartItem is not null)
                IsCartEmpty = true;

            Thread.Sleep(TIMEOUT_LONG);
            IWebElement btn_medium= wait.Until(c => c.FindElement(By.CssSelector(".btn_medium")));
            btn_medium.Click();
            Thread.Sleep(TIMEOUT_SHORT);
            Assert.IsTrue(IsCartEmpty);
        }
    }
}
