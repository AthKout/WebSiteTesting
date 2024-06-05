using OpenQA.Selenium;

namespace WebSiteTesting
{
    [TestFixture]
    public class TestFormSubmission: BaseTest
    {

        [Test]
        [Description("Test case to validate the submission of a form and the checkout functionality.")]
        public void SubmitForm()
        {
            // Login to the site
            LogIn(); 
            Thread.Sleep(TIMEOUT_LONG);
            // Click on the first product
            IWebElement btn_inventory = wait.Until(c => c.FindElement(By.CssSelector(".btn_inventory")));
            btn_inventory.Click();
            Thread.Sleep(TIMEOUT_LONG);
            // Click on the shopping cart icon
            IWebElement shopping_cart_link = wait.Until(c => c.FindElement(By.CssSelector(".shopping_cart_link")));
            shopping_cart_link.Click();
            Thread.Sleep(TIMEOUT_LONG);
             // Click on the Checkout button
            IWebElement checkout_button = wait.Until(c => c.FindElement(By.CssSelector(".checkout_button")));
            checkout_button.Click();
            Thread.Sleep(TIMEOUT_MED);
            // Fill in the shipment details
            IWebElement first_name = wait.Until(c => c.FindElement(By.Id("first-name")));
            first_name.SendKeys("Nick");
            Thread.Sleep(TIMEOUT_SHORT);
            IWebElement last_name = wait.Until(c => c.FindElement(By.Id("last-name")));
            last_name.SendKeys("Jackson");
            Thread.Sleep(TIMEOUT_SHORT);
            IWebElement postal_code = wait.Until(c => c.FindElement(By.Id("postal-code")));
            postal_code.SendKeys("8200");
            Thread.Sleep(TIMEOUT_SHORT);
            // Click on the Continue button
            IWebElement btn_primary = wait.Until(c => c.FindElement(By.CssSelector(".btn_primary.cart_button")));
            btn_primary.Click();
            Thread.Sleep(TIMEOUT_LONG);
            Assert.IsTrue(driver.Url.Contains("/checkout-step-two"));
        }
    }
}
