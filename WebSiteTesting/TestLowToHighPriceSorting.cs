using OpenQA.Selenium;

namespace WebSiteTesting
{
    public class TestLowToHighPriceSorting : BaseTest
    {
        [Test]
        [Description("Test the sorting of products based on price, from low to high.")]
        public void SortLowToHighPrice()
        {
            // Login to the site
            LogIn();
            Thread.Sleep(TIMEOUT_MED);
            // Click on the dropdown to open it
            IWebElement product_sort_container = wait.Until(c => c.FindElement(By.CssSelector(".product_sort_container")));
            product_sort_container.Click();
            Thread.Sleep(TIMEOUT_SHORT);
            // Find and click on the option to sort by low price
            IWebElement option = wait.Until(c => c.FindElement(By.CssSelector("option[value='lohi']")));
            option.Click();
            Thread.Sleep(TIMEOUT_LONG);
            // Wait for the page to reload with the sorted products
            wait.Until(c => c.FindElement(By.CssSelector(".inventory_item")));
            Thread.Sleep(TIMEOUT_MED);
            wait.Until(c => c.FindElement(By.CssSelector(".inventory_item_price")));
            // Get the list of product prices
            IList<IWebElement> productPrices = driver.FindElements(By.CssSelector(".inventory_item_price"));
            // Convert the product prices to decimal values for comparison
            List<decimal> prices = ExtractPrices(productPrices);
            // Check if the prices are sorted in ascending order
            bool sorted = prices.SequenceEqual(prices.OrderBy(p => p));
            Assert.IsTrue(sorted, "Products are not sorted by low price");
        }
    }
}
