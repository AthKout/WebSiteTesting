using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Globalization;

namespace WebSiteTesting
{
    [TestFixture, Ignore("Base class for inheritance, no test case here.")]
    public class BaseTest
    {   
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected const int TIMEOUT_LONG = 3000;
        protected const int TIMEOUT_MED = 2000;
        protected const int TIMEOUT_SHORT = 1000;

        [SetUp]
        public void Setup()
        {
            // set up the Google Crhome driver 
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // maximize the Chrome Window
            driver.Manage().Window.Maximize();
            // provide the link of saucedemo web site
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                // after the tests quit and kill the driver 
                driver.Quit();
                driver.Dispose();
            }
        }

        public void LogIn(bool UseFalsePassword = false)
        {
            // provide one of the legit usernames and password to log in to the site
            // if UseFalsePassword = false then provide a false password
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            Thread.Sleep(TIMEOUT_SHORT);
            driver.FindElement(By.Id("password")).SendKeys(UseFalsePassword ? "invalid_password" : "secret_sauce");
            Thread.Sleep(TIMEOUT_SHORT);
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
        }

        public List<decimal> ExtractPrices(IList<IWebElement> productPrices)
        {
            // Convert the product prices to decimal values for comparison
            List<decimal> prices = new List<decimal>();
            foreach (IWebElement element in productPrices)
            {
                string priceString = element.Text.Replace("$", "").Trim();
                decimal price = decimal.Parse(priceString, CultureInfo.InvariantCulture);
                prices.Add(price);
            }
            return prices;
        }

        public List<string> ExtractNames(IList<IWebElement> productNames)
        {
            // Convert the product names to strings for comparison
            List<string> names = new List<string>();
            foreach (IWebElement element in productNames)
            {
                string name = element.Text.Trim();
                names.Add(name);
            }
            return names;
        }
    }
}