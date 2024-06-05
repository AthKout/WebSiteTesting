using OpenQA.Selenium;

namespace WebSiteTesting
{
    [TestFixture]
    public class TestAlphabeticalAscendingSorting : BaseTest
    {
        [Test]
        [Description("Test case to validate the ascending alphabetical sorting of all products, A to Z.")]
        public void SortAlphabeticallyAscending()
        {
            // Login to the site
            LogIn();
            Thread.Sleep(TIMEOUT_MED);
            // Click on the dropdown to open it
            IWebElement product_sort_container = wait.Until(c => c.FindElement(By.CssSelector(".product_sort_container")));
            product_sort_container.Click();
            Thread.Sleep(TIMEOUT_SHORT);
            // Find and click on the option to sort alphabetically from Z to A
            IWebElement option = wait.Until(c => c.FindElement(By.CssSelector("option[value='az']")));
            option.Click();
            Thread.Sleep(TIMEOUT_LONG);
            // Wait for the page to reload with the sorted products
            wait.Until(c => c.FindElement(By.CssSelector(".inventory_item")));
            Thread.Sleep(TIMEOUT_LONG);
            // Get the list of product names
            IList<IWebElement> productNames = driver.FindElements(By.CssSelector(".inventory_item_name"));
            // Convert the product names to strings for comparison
            List<string> names = ExtractNames(productNames);
            // Check if the names are sorted in descending order
            bool sorted = names.SequenceEqual(names.OrderBy(n => n));
            Assert.IsTrue(sorted, "Products are not sorted alphabetically from A to Z");
        }
    }
}
