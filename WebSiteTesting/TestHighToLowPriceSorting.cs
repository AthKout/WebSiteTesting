using OpenQA.Selenium;

namespace WebSiteTesting
{
    public class TestHighToLowPriceSorting : BaseTest
    {
        [Test]
        [Description("Test the products' sorting based on price, from high to low.")]
        public void SortHighToLowPrice()
        {
            //Login to the site
            LogIn();
            Thread.Sleep(TIMEOUT_MED);
            // Click on the dropdown to open it
            IWebElement product_sort_container = wait.Until(c => c.FindElement(By.CssSelector(".product_sort_container")));
            product_sort_container.Click();
            Thread.Sleep(TIMEOUT_SHORT);
            // Find and click on the option to sort by high price
            IWebElement option = wait.Until(c => c.FindElement(By.CssSelector("option[value='hilo']")));
            option.Click();
            Thread.Sleep(TIMEOUT_LONG);
            // Wait for the page to reload with the sorted products
            wait.Until(c => c.FindElement(By.CssSelector(".inventory_item")));
            // Get the list of product prices
            wait.Until(c => c.FindElement(By.CssSelector(".inventory_item_price")));
            IList<IWebElement> productPrices = driver.FindElements(By.CssSelector(".inventory_item_price"));
            // Convert the product prices to decimal values for comparison
            List<decimal> prices = ExtractPrices(productPrices);
            // Check if the prices are sorted in ascending order
            bool sorted = prices.SequenceEqual(prices.OrderByDescending(p => p));
            Assert.IsTrue(sorted, "Products are not sorted by high price");
        }
    }
}
